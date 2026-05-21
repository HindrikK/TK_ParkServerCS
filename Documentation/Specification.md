# Eleon SCADA

Framework version: .NET Framework 4.8; Windows Forms desktop application.

## **Overview**

Eleon SCADA is a Windows Forms supervisory application for a wind park. The current application startup creates one Vestas V80 turbine, named `T01`, and uses that turbine as the active park model. The application monitors turbine state, electrical values, wind speed, production data, communication status. Application has modules for alarm announcements, data logging and IEC 60870-5-104 server integration.

The application is single-instance. Startup is blocked if another process owns the `Eleon_SCADA` mutex.

## **Runtime Startup**

At startup the application performs the following sequence:

1. Shows the startup form.
2. Checks the license. If the license check fails, the application warns the
   user and schedules automatic shutdown after 60 seconds.
3. Loads settings from `%APPDATA%\Eleon_SCADA\Settings.xml`.
4. Loads `PowerCurve_V80.txt`.
5. Creates the wind park and adds one `Vestas V80` turbine (`T01`).
6. Creates the Vestas serial controller.
7. Creates and starts alarm dispatch.
8. Creates the IEC-104 server and IEC-104 interface mapper.
9. Creates and starts the Market Interface server when enabled in settings.
10. Creates the memory-mapped interop service.
11. Opens Access database connections and starts database logging.
12. Auto-connects the park serial controller when enabled in settings.
13. Auto-starts the IEC-104 server when enabled in settings.
14. Opens the main form.

On application exit, the Market Interface server is stopped and the
memory-mapped interop service is disposed.

## **Application Settings**

Settings are read from `%APPDATA%\Eleon_SCADA\Settings.xml`.

The AppData folder path is supplied by Windows. During settings load the
application ensures that the `%APPDATA%\Eleon_SCADA` directory exists. If
`Settings.xml` is missing, the application creates it with a `Settings` root
element and then writes all declared default parameters into the file. If a
known settings section or parameter is missing, the application adds it with
the current in-code default value and saves the repaired XML file. If a
parameter exists but cannot be converted to the expected type, loading fails
with an error message so the user can manually correct the value.

An existing XML file must use `Settings` as its root element. A file with a
different root element is treated as invalid rather than overwritten.

Settings are grouped into these sections:

| Section | Purpose |
| --- | --- |
| `AlarmDispatch` | SMTP server, sender, default recipient, trigger delay, active recipients and excluded status codes. |
| `Application` | Auto-connect park, auto-start IEC-104 and auto-logout time. |
| `Database` | Access database folder path and fast sample time. |
| `VestasDriver` | Serial port, baud rate, polling intervals, parity and communication timeouts. |
| `IEC104Server` | IP address, TCP port, periodic transmission settings, max clients, reconnect delay and ASDU. |
| `Park` | Local, TSO and market active power setpoints, park maximum power, breaker status and setpoint mode. |
| `T01` | Turbine-specific primary regulation parameters and automatic error acknowledge list. |
| `MarketInterface` | Market Interface Modbus TCP/UDP enable state, bind address, ports, connection limits and rate/timeouts. |

Default values declared in code include:

| Setting | Default |
| --- | --- |
| Application auto-connect park | `true` |
| Application auto-start IEC-104 | `true` |
| Auto logout | `600 s` |
| Database path | `Database\` |
| Database sample time | `60000 ms` |
| Vestas serial port | `COM1` |
| Vestas baud rate | `9600` |
| Vestas fast poll | `500 ms` |
| Vestas slow poll | `1000 ms` |
| Vestas communication timeout | `200 ms` |
| Vestas communication status timeout | `3500 ms` |
| IEC-104 server IP | `0.0.0.0` |
| IEC-104 server port | `2404` |
| IEC-104 max clients | `10` |
| IEC-104 reconnect delay | `20 s` |
| IEC-104 ASDU | `3` |
| Park maximum power | `2000 kW` |
| Local active power setpoint | `2000 kW` |
| TSO active power setpoint | `2000 kW` |
| Market active power setpoint | `2000 kW` |
| T01 nominal power | `2000 kW` |
| T01 power ramping | `100` |
| T01 nominal frequency | `50 Hz` |
| T01 primary regulation emergency reset delay | `600 s` |
| T01 setpoint send rate | `2 s` |
| T01 automatic error acknowledge delay | `20 s` |
| Market Interface enabled | `false` |
| Market Interface bind IP | `0.0.0.0` |
| Market Interface TCP port | `502` |
| Market Interface UDP port | `502` |
| Market Interface TCP enabled | `true` |
| Market Interface UDP enabled | `true` |
| Market Interface maximum active connections | `3` |
| Market Interface stale connection timeout | `60 s` |
| Market Interface response rate limit | `100 ms` |
| Market Interface fallback timeout | `900 s` / 15 minutes |

Recipient lists, excluded alarm status lists and automatic error acknowledge
lists are stored as Base64-encoded `BinaryFormatter` payloads in the XML.

## **Licensing**

The application uses a local file-based license check. License data is read
from `License.dat` in the application working directory.

`License.dat` is expected to contain three lines:

| Line | Value |
| --- | --- |
| `1` | License owner. |
| `2` | License number. |
| `3` | License hash. |

The license check reads the current hardware ID from the first
`win32_processor` WMI `processorID` value. A license is considered valid when
the stored license hash matches the SHA-256 based hash generated from:

```text
<HardwareID><LicenseOwner><LicenseNumber>
```

The hash calculation appends the in-code salt before hashing, encodes the
input as Unicode, calculates a SHA-256 hash and stores the result as Base64.

Licensing behavior:

- Startup calls `Licensing.CheckLicense()` before loading settings.
- If no valid license is found, the application shows a warning that some
  functionality has been disabled and starts a 60-second shutdown timer.
- When the no-license timer elapses, the main form closing confirmation is
  disabled and the application exits.
- The IEC-104 server refuses to start without a valid license.
- The Vestas serial controller refuses to open its communication port without
  a valid license.
- The Market Interface server refuses to start without a valid license.
- The License dialog shows the hardware ID. When a valid license exists, it
  also shows the license owner and license number; otherwise the license
  information group is hidden.

## **User Access Levels**

The main form supports four user levels:

| Level | Name | Enabled functionality |
| --- | --- | --- |
| `0` | Logged out | Monitoring only. Control, service and debug functions are hidden or disabled. |
| `1` | Administrator | Enables the turbine control menu and control tab when turbine communication is available. |
| `2` | Service | Includes administrator access and enables service controls. |
| `10` | Developer | Includes service access and adds the developer/debug menu. |

Login credentials are currently hard-coded in the main form source. The
auto-logout timer is reloaded from settings after login and logs the user out
when it elapses.

## **Main User Interface**

The main form refreshes display values with fast and slow timers.

Fast refresh updates:

- Park active power and wind speed.
- T01 power, wind speed, pitch angle, generator RPM, state and error code.
- T01 operation and pending operation states.
- Electrical values: active power, cos phi, frequency, phase voltages and
  phase currents.

Slow refresh updates:

- Park production.
- T01 service, yaw, remote-control, availability and generator connection
  status.
- Turbine communication state and tab coloring.
- Human-readable state, error, operation and yaw texts.
- Active/reactive power setpoints.
- Setpoint mode display: no setpoint, local setpoint or remote setpoint.
- Database and IEC-104 server status labels.

Available dialogs and tools include preferences, database settings, IEC-104
server settings, IEC-104 interface, Market Interface settings/status, alarm dispatch,
turbine settings, park settings, turbine communication, communication
statistics, communication terminal/logs, data charts, production view, error
logs, Vestas parameter tool, license dialog, about dialog and developer/debug
form.

## **Wind Park Model**

The park model currently allocates storage for one active turbine and calculates
park aggregate values from `T01`. The park update timer runs every `100 ms`.

Park-level monitored values include:

- Wind speed and wind direction.
- Yaw position.
- Active and reactive power.
- Voltage and current.
- Grid-connected state.
- Communication statistics: transmitted frames, received frames and errors.

Park-level controls include:

- Start park.
- Stop park. In the current Vestas turbine wrapper this maps to pause turbine, because Vestas does not have "Stop" command.
- Active power setpoint dispatch.

Active power setpoint handling:

- The park has a maximum active power limit setting.
- All active setpoints are clamped to the maximum active power.
- Active power setpoint control has different modes.
- Setpoint mode `0` - automatic, takes smallest of all setpoints.
- Setpoint mode `1` - local, configured in the application.
- Setpoint mode `2` - TSO interface.
- Setpoint mode `3` - market interface.
- All setpoints are persisted to settings so that it can recover after application restart.

## **T01 Vestas Turbine Model**

The turbine model stores the current values collected from the Vestas
controller. These include:

- Communication status and communication counters.
- Active power, generator RPM, rotor RPM, wind speed, pitch angle, state and
  error code.
- One-second wind data: wind speed, wind direction, relative wind direction and
  nacelle direction.
- One-second electrical data: active power, cos phi, frequency, phase voltages
  and phase currents.
- Operation state, pending operation state, service state, yaw state, command
  accepted state and remote-control availability.
- Turbine availability, VDF trigger, local mode request and generator
  connection states.
- Temperature values for hydraulic system, environment, gear, generator,
  slipring, bearings, hub, nacelle, top controller, busbar, spinner,
  transformers and cooling water.
- Active power setpoint, reactive power setpoint, nominal power and active power
  regulator setpoint.
- Production hours, production and reactive power.

The turbine wrapper exposes active power setpoint, start, stop/pause and reset
operations through the Vestas controller.

## **Vestas Serial Controller**

The Vestas controller runs a background thread and communicates with the turbine
through a serial port. It uses timers for:

- Communication status timeout per turbine.
- Fast polling.
- Slow polling.
- Ten-second polling.
- Request timeout.
- Automatic error acknowledge delay.

When the port is opened, polling intervals and communication timeouts are loaded
from settings. The controller polls overview data, wind data, electrical data,
temperature data, power setpoint data, production data and VGMS overview data.

Supported controller actions include:

- Start turbine.
- Pause turbine.
- Acknowledge errors.
- Set active power setpoint.
- Set reactive power setpoint.
- Change turbine parameters.

Automatic error acknowledgement checks the configured `T01.AutoResetError`
status list and uses `T01.AutoErrorAckDelay` before sending reset/start related
commands.

## **Database Logging**

Database logging uses Microsoft Jet OLE DB 4.0 and one Access `.mdb` file per
turbine. The connection path is:

```text
<Database.Path>\<TurbineName>.mdb
```

For the current park this resolves to the configured database path plus
`T01.mdb`.

Logging starts only when all database connections open successfully. The
database logger runs in a background thread and starts three timers:

| Timer | Interval | Action |
| --- | --- | --- |
| Fast data | `Database.SampleTime` | Writes `Data_1` records when the Vestas port is open. |
| Slow data | `900000 ms` / 15 minutes | Writes `Data_2` records when the Vestas port is open. |
| Status | `500 ms` | Detects error code changes and writes `Status` records. |

Logged records:

| Table | Fields written by application |
| --- | --- |
| `Status` | `Time`, `Status` |
| `Data_1` | `Time`, `WindSpeed`, `ActivePower` |
| `Data_2` | `Time`, `YawPosition`, `Hours`, `Production` |

Logging exceptions are announced by email to the default alarm dispatch address
where possible.

## **Alarm Announcement**

Alarm dispatch runs in a background thread and checks alarms once per second.
It can be enabled and disabled at runtime from the main window.

Alarm triggering behavior:

- A turbine status change can trigger an alarm.
- Loss of turbine communication can trigger an alarm.
- Triggering is delayed by the configured `AlarmDispatch.TriggerDelay`.
- Excluded status codes do not trigger alarm email.
- Alarm email is sent to active recipients.

SMTP settings include server, port, timeout, subject and sender address.

The alarm dispatcher also supports:

- Sending an announcement to all active recipients.
- Sending an announcement to a specific address.
- Sending a test alarm.
- Resending messages from the outbox.
- Clearing outbox and sent-message buffers.

The outbox and sent-message buffers each keep up to 50 messages.

## **TSO Interface**

TSO interface is implemented on IEC-104 server. It listens on the configured IP address and TCP port. It checks
the license before starting and refuses start when the license is not valid.

Server behavior:

- Uses one background listener thread.
- Creates one IEC-104 channel thread per accepted client.
- Limits clients by `IEC104Server.MaxNoOfClients`.
- Tracks server status as stopped, starting, error starting, waiting restart or
  running.
- On listener start failure, waits `IEC104Server.ReconnectTime` seconds before
  retrying.
- On stop, closes all active channels and stops the TCP listener.

Configured IEC-104 settings:

| Setting | Default | Meaning |
| --- | --- | --- |
| `ServerIP` | `0.0.0.0` | Local IP address to bind. |
| `Port` | `2404` | TCP listening port. |
| `MaxNoOfClients` | `10` | Maximum simultaneously accepted clients/channels. |
| `ReconnectTime` | `20 s` | Delay before retry after listener start failure. |
| `ASDU` | `3` | Common ASDU address. |
| `periodicTransmission` | `false` | Enables periodic transmission behavior in settings. |
| `periodicPeriod` | `5000 ms` | Periodic transmission interval. |

## IEC-104 Interface Mapping

The IEC-104 interface maps between the IEC-104 database and the park model every
`100 ms`. It also supports a simulation mode that maps IEC values to simulation
variables instead of the real park variables.

Monitoring points:

| IOA | Type | Name | Unit / scale |
| --- | --- | --- | --- |
| `1001` | `M_ME_NC` | Wind speed | m/s |
| `1002` | `M_ME_NC` | Voltage | kV |
| `1003` | `M_ME_NC` | Active power | MW |
| `1004` | `M_ME_NC` | Reactive power | MVar |
| `1005` | `M_ME_NC` | Current | A |
| `1006` | `M_ME_NC` | Active power setpoint monitor | 100 kW steps |
| `2001` | `M_SP_NA` | Park operation / grid connected | Boolean |
| `2002` | `M_SP_NA` | Park MV breaker | Boolean |
| `2003` | `M_SP_NA` | Secondary regulation active | Boolean |
| `2004` | `M_SP_NA` | 80 percent emergency limit active | Boolean |
| `2005` | `M_SP_NA` | 60 percent emergency limit active | Boolean |
| `2006` | `M_SP_NA` | 40 percent emergency limit active | Boolean |
| `2007` | `M_SP_NA` | 20 percent emergency limit active | Boolean |

Control points:

| IOA | Type | Name | Behavior |
| --- | --- | --- | --- |
| `1` | `C_SC_NA` | 80 percent emergency limit | Activates 80 percent park maximum remote setpoint and clears IOA 2-4. |
| `2` | `C_SC_NA` | 60 percent emergency limit | Activates 60 percent park maximum remote setpoint and clears IOA 1, 3 and 4. |
| `3` | `C_SC_NA` | 40 percent emergency limit | Activates 40 percent park maximum remote setpoint and clears IOA 1, 2 and 4. |
| `4` | `C_SC_NA` | 20 percent emergency limit | Activates 20 percent park maximum remote setpoint and clears IOA 1-3. |
| `5` | `C_SC_NA` | Park start/stop | `true` starts the park; `false` stops/pauses the park. |
| `6` | `C_SC_NA` | Secondary regulation | When active, remote setpoint follows IOA 6201. When inactive, remote setpoint returns to park maximum. |
| `6201` | `C_SE_NA` | Active power setpoint | Stored in 100 kW steps and applied to the park as value multiplied by 100. |

Test object groups also exist in the IEC database:

| IOA range | Type | Notes |
| --- | --- | --- |
| `3000-3002` | `M_DP_NA` | Test double-point monitoring data. |
| `4000-4002` | `C_DC_NA` | Test double-command data. |

## **Market Interface**

### **Functionality**
Market interface is created during application startup when a valid license is present.<br>
It is started when `Settings.MarketInterface.MarketIfEnable` is `true`.<br>
It is stopped when `Settings.MarketInterface.MarketIfEnable` is `false` and also during application shutdown.<br>
The Tools menu contains a Market Interface dialog (`Form_MarketInterface`) for editing the settings and starting or stopping the server at runtime, plus a status dialog showing active connections.

Control includes only active power setpoint. Market interface has active power setpoint `Market_ActivePowerSetpoint` which is updated from the Modbus register. But in case the market interface is offline/down for more than `Settings.MarketInterface.FallbackTimeout`, `Market_ActivePowerSetpoint` will revert to park max power value so that park won't be limited indefinetly when interface is down. Market limit will also be reverted when interface is disabled.

### **Interface Protocol**
The Market Interface is implemented as a Modbus TCP/UDP server integration based on the `TQ_ModbusServerCS` .NET Framework 4.8 submodule.

The Modbus library supports:

- TCP and UDP listeners.
- Functions `01`, `02`, `03`, `04`, `05`, `06`, `15` and `16`.
- Coils, discrete inputs, holding registers and input registers.
- Configurable IP address, TCP/UDP ports, maximum active connections, stale
  timeout and response rate limit.
- Register mappings to byte buffers, numeric callbacks, strings or register
  blocks.
- Unique and non-overlapping register blocks.

#### **Registers Table**

| | Adr | &nbsp;&nbsp;&nbsp;Name | Reg. Type | Access | Value<br>type | Unit | Decimal<br>step | Default | Min | Max |
| --- | ---: | --- | :---: | :---: | :---: | :---: | :---: | ---: | ---: | ---: |
| | | | | | | | | | | |
|1| 100 | Active Power SP (MW) | HR | R/W | uint16 | MW | 0.1 | 1.8 | 0 | 1.8 |
|2| 101 | Active Power SP (pct) | HR | R/W | uint16 | % | 0.1 | 100 | 0 | 100 |
| | | | | | | | | | | |
|3| 500 | Park Status | IR | R | uint16 | binary | - | 0 | 0 | - |
|4| 501 | Park Active Power | IR | R | int16 | MW | 0.1 | - | - | - |
|5| 502 | Park Wind Speed | IR | R | uint16 | m/s | 0.1 | - | 0 | - |
| | | | | | | | | | | |
|6| 1000 | Turbine #1 Status | IR | R | uint16 | binary | - | 0 | 0 | - |
|7| 1001 | Turbine #1 Active Power | IR | R | int16 | kW | 0 | - | - | - |
|8| 1002 | Turbine #1 Wind Speed | IR | R | uint16 | m/s | 0.1 | - | 0 | - |


Notes:

- Status registers (500 and 1000) are placeholders and currently not implemented.
- Park active power can be controlled either by register 100 or 101. Writing either one will also automatically adjust the other.

### Market Interface Logs

Interface events will be logged in a dedicated Market Interface log. Every log entry consists timestamp (`MM.dd HH:mm:ss`) and description. Logs are accessible from a separate form accessed through Market Interface settings form. Log window is refreshed automatically to show logs in realtime.<br>
Maximum log size is last 1000 logs, older logs will be overwritten. Realtime logging will be handled in volatile memory (RAM).<br>
When unsaved logs exist then every 10 min or when program exits, the logs will be saved in a CSV file in "logs" folder inside program folder. If the logs folder does not exist then it will be created. Filename template is `MarketLog_YYMMDD_hhmmss.csv`. Filename includes timestamp of first log in file. When program starts, existing logs will be loaded from the latest file. Maximum size of the log file is one month or 1000 logs (same as log in memory). When maximum log or file size is reached a new file will be created.

These are the events that will be logged:
- Interface manual enable/disable
- Market Interface server started
- Market Interface server stopped
- Market Interface server stopped unexpectedly with error description
- Modbus client connected
- Modbus client disconnected/stale
- Modbus client refused
- Modbus request for power setpoint change (with new setpoint value)

## **Interprocess Interface**

The application creates or opens a memory-mapped file named
`WindParkServer_Map` with one byte of storage. The `ProgramHeartBeat` property
writes a byte to offset `1` of this map when set.

## **Known Implementation Notes**

- The application currently creates one turbine (`T01`) in code.
- Login credentials are hard-coded in source.
- Some configuration lists are serialized with `BinaryFormatter`.
- Market Interface status and command registers are placeholders and are not
  yet linked to live turbine or park variables.


## **User Interface**

### **Main window**

The main window is `Form_Main` and is titled `Eleon SCADA`. It is the primary
operator view for monitoring the current park and turbine, opening settings and
diagnostic tools, and executing permitted controls. The menu bar and status bar
use a light steel blue base color. Status labels are bordered/sunken
`ToolStripStatusLabel` controls so important system states remain visible from
all tabs.

The main window has a top park summary area that shows park active power, park
wind speed and park production. The central area is a turbine tab control. The
current application creates one turbine tab, `T01 - Vestas V80`, with these
sub-tabs:

| Tab | Purpose |
| --- | --- |
| `Overview` | Main turbine operating overview: active power, wind speed, generator speed, state code, operation state, pending operation state, error code, service state, yaw status, remote-control status, turbine availability, generator connection and human-readable state/error/yaw text. |
| `Electrical` | Electrical and production values: one-second active power, cos phi, frequency, phase voltages, phase currents, production, active power regulator setpoint, active power setpoint and reactive power setpoint. |
| `Temperatures` | Turbine temperature values: hydraulic system, environment, gear, generator, slipring, bearings, hub, nacelle, top controller, busbar, spinner, transformers and cooling water. |
| `Control` | Turbine service and control commands. This tab is removed while logged out and added after administrator login. Service controls inside it are disabled until service-level login. |

The main form uses two UI refresh timers:

| Timer | Interval | Behavior |
| --- | ---: | --- |
| Fast update | `300 ms` | Refreshes top park active power/wind speed, overview measurements and electrical values. |
| Slow update | `1000 ms` | Refreshes production, service/yaw/remote/availability statuses, turbine communication visual state, active setpoint display, temperatures, service setpoint labels, bottom status labels and alarm announcement button state. |

### **Menus**

The main menu contains these top-level menus:

| Menu | Items | Behavior |
| --- | --- | --- |
| `Application` | `Connect turbine`, `Start TSO link`, `Preferences...`, `Close` | Connects or disconnects the Vestas serial controller, starts/stops the IEC-104 server, opens application preferences or closes the main form. Disconnecting the turbine and stopping the TSO link ask for confirmation. |
| `Tools` | `Logs`, `TSO Interface`, `Developer` | Opens diagnostics and data views. `Developer` is removed from the menu while logged out and is added only for developer login. |
| `Tools > Logs` | `Status logs`, `Data charts`, `Production` | Opens status/error logs, charted logged data and production data views. |
| `Settings` | `Park`, `Turbines`, `TSO Interface`, `Market Interface`, `Alarm announcement`, `Communication`, `Database` | Opens configuration forms for park control, turbine settings, IEC-104 settings, Market Interface settings, alarm dispatch, communication and database logging. |
| `Settings > Communication` | `Vestas COM`, `Add Interface...` | Opens Vestas serial communication settings. `Add Interface...` exists in the menu but is disabled. |
| `Control` | `Start park`, `Stop park` | Sends park start or stop/pause commands after confirmation. The menu is disabled while logged out and also disabled when the turbine port is disconnected. |
| `Info` | `About`, `License` | Opens application information and license dialogs. |

The `Connect turbine` menu item is dynamic. It shows `Connect turbine` while
the Vestas port is closed and `Disconnect turbine` while it is open. The IEC-104
menu item similarly changes between `Start TSO link` and `Stop TSO link` based
on server status after the status refresh method runs.

### **Login and access behavior**

The user level label in the main window works as both login indicator and login
button. When logged out it shows `LOGIN`, has a dark gray background and white
text. Clicking it opens the login dialog. Clicking it while already logged in
logs the user out.

| User level | Label text | UI behavior |
| --- | --- | --- |
| Logged out | `LOGIN` | Control menu disabled, `Control` turbine tab removed, service group disabled and `Developer` menu hidden. |
| Administrator | `ADMINISTRATOR` | Adds the turbine `Control` tab. Enables the `Control` menu when turbine communication is available. |
| Service | `SERVICE` | Includes administrator behavior and enables the service function group inside the turbine `Control` tab. |
| Developer | `DEVELOPER` | Includes service behavior and adds `Tools > Developer`. |

Administrator, service and developer states use a gold login label background
with black text. After login, the auto-logout timer is enabled and its interval
is loaded from `Settings.Application.AutoLogoutTime`. Auto logout returns the UI
to the logged-out state.

### **Status bar visuals**

The bottom status bar contains connection, logging, setpoint and external
interface indicators.

| Label | Text / color behavior |
| --- | --- |
| `StatusLabel_ParkConnection` | `Disconnected` with light steel blue background when the Vestas port is closed. `Connected` with light steel blue background when the port is open and turbine communication is healthy. `Comm Error` with red background when the port is open but turbine communication status is false. Clicking the label opens `Form_CommStats` at the lower-left edge of the main form. |
| `StatusLabel_DatabaseStatus` | `Database online` when database connections are active, otherwise `Database offline`. The default text is `No data logging`. |
| `StatusLabel_SetpointMode` | Shows `Automatic setpoint`, `Local setpoint`, `TSO setpoint` or `Market setpoint` according to `Program.myPark.ActivePowerSetpoint_Mode`. |
| `StatusLabel_PowerSetpoint` | Shows the selected active power setpoint and park maximum power in the form `<setpoint> / <max> kW`. Automatic mode displays the minimum of local, TSO, market and park maximum setpoints. |
| `StatusLabel_Market` | `Market Ctrl Off` with gray background when Market Interface is disabled. `Market Ctrl Down` with yellow background when enabled but there are no active Modbus clients. `Market Ctrl OK` with green background and white text when at least one Modbus client is active. |
| `StatusLabel_TSOLink` | `TSO link stopped` with gray background when stopped. `TSO link start...` with yellow background while starting. `TSO link error` with red background on start error. `TSO reconn. in: <seconds> s` with yellow background while waiting to retry. `TSO link down` with yellow background when running with no IEC-104 clients. `TSO link OK (<n> clients)` with green background and white text when at least one client is connected. |

The `T01` turbine tab itself is also used as a communication visual. It is
colored steel blue when `T01.CommunicationStatus` is true and red when
communication is lost. The `No communication` label is hidden during healthy
communication and visible during communication loss.

### **Forms and dialogs**

| Form / dialog | Opened from | Purpose and behavior |
| --- | --- | --- |
| `Form_Startup` | Startup | Splash/loading form shown during startup. |
| `Form_Main` | Startup | Main monitoring and control window. |
| `Form_Preferences` | `Application > Preferences...` | Edits `Auto connect park`, `Auto start IEC-104 server` and user auto-logout time. OK saves `Settings.Application`. |
| `Form_ParkSettings` | `Settings > Park` | Edits park active power control settings: setpoint mode, local active power setpoint, TSO setpoint display, Market setpoint display and park maximum power. TSO, market and ramping fields are currently disabled in the dialog. OK updates `Program.myPark` and persists `Settings.Park`. |
| `Form_TurbineSettings` | `Settings > Turbines` | Edits turbine general settings such as nominal power and active power ramping. It also contains communication interface/turbine selection fields, auto-reset settings access and frequency controller access. Auto-reset is visible for administrator and higher; frequency controller is visible for developer. |
| `Form_TurbineCommunication` | `Settings > Communication > Vestas COM` | Edits Vestas serial communication settings: port, baud rate, parity, fast/slow poll intervals, response timeout and communication status timeout. It can open communication statistics. |
| `Form_IEC104Settings` | `Settings > TSO Interface` | Edits IEC-104 server settings: maximum clients, listener IP, port, ASDU, reconnect time, periodic transmission period and periodic transmission enable. The period field is enabled only when periodic transmission is checked. |
| `Form_MarketInterface` | `Settings > Market Interface` | Edits Market Interface Modbus settings: enable state, fallback timeout, IP address, UDP/TCP ports, UDP/TCP enable flags, maximum active connections, stale connection timeout and response rate limit. OK saves settings, stops any existing server instance, and starts a new one when enabled. The `Status` button is enabled only when the Modbus server instance exists. |
| `Form_ModbusStatus` | `Form_MarketInterface > Status` | Shows active Modbus connections with connection time, transport, address, port and last valid request. Refreshes periodically and shows `Market Interface server is not running.` when the server object does not exist. |
| `Form_MarketInterfaceLogs` | `Form_MarketInterface > Logs` | Shows Market Interface log entries in a resizable standalone window. The window refreshes automatically, supports pause/start of screen updates and keeps the most recent 1000 entries. |
| `Form_TSOInterface` | `Tools > TSO Interface` | Displays IEC-104 active clients/channels, live monitoring values and control signal values. Service functions button is visible only for service level or higher and opens the IEC-104 test/service form. |
| `Form_TSOInterfaceInterface_Test` | `Form_TSOInterface > Service functions...` | IEC-104 interface testing/service form for simulation and service-level verification. |
| `Form_AlarmAnnouncement` | `Settings > Alarm announcement` | Configures alarm email server/port/from/subject, delayed trigger time, recipients, excluded status codes and outbox/sent message buffers. Provides add/remove/activate/deactivate recipient actions, test email, resend, clear and default actions. |
| `Form_AlarmAnnouncementStatusCodes` / `Dialog_AddExcludedStatus` | `Form_AlarmAnnouncement` | Maintains the excluded alarm status code list. |
| `Form_AutoResetErrors` / `Dialog_AddAutoResetCode` | `Form_TurbineSettings` | Maintains the automatic reset error code list and automatic error acknowledge delay. |
| `Form_DatabaseSettings` | `Settings > Database` | Edits database folder path and logging sample time. Includes a Browse button for selecting a path. |
| `Form_CommStats` | Park connection status label or communication settings | Shows park/turbine communication counters and statistics. |
| `Form_CommTerminal` | Communication tooling | Shows sent/received communication frames and supports terminal logging controls. |
| `Form_CommErrorLog` | Communication tooling | Shows communication error log entries from the Vestas controller. |
| `Form_ErrorLogs` | `Tools > Logs > Status logs` | Shows stored status/error log records. |
| `Form_DataCharts` | `Tools > Logs > Data charts` | Shows logged data in chart form. |
| `Form_Production` | `Tools > Logs > Production` | Shows turbine production information. |
| `Form_VestasParameterTool` | Turbine `Control` tab | Developer/service tool for reading and changing Vestas turbine parameters. |
| `Form_FrequencyController` | Turbine settings / developer tools | Frequency controller service/development form. |
| `Form_Developer` | `Tools > Developer` | Developer/debug form; available only after developer login. |
| `Dialog_License` | `Info > License` | Shows hardware ID and license information. If no valid license exists, the license information group is hidden and `No License` is shown. |
| `Dialog_About` | `Info > About` | Shows application information. |
| `Dialog_AddUser` | Alarm recipient workflow | Adds a recipient to the alarm announcement recipient list. |
| `Dialog_VestasPowerControl` | Vestas-related control workflow | Vestas power control dialog retained in the project. |

### **Operator confirmations and error handling**

Potentially disruptive operator actions use confirmation dialogs: disconnecting
the turbine, stopping the TSO interface, starting the park and stopping the
park.<br>
Exceptions raised from menu actions and refresh functions are shown with
modal message boxes containing the exception message and the source context.

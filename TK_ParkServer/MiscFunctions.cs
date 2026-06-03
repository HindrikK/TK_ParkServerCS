using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TK_ParkServer
{
    /// <summary>
    /// All kinds of useful functions that can be used anywhere
    /// </summary>
    static class Misc_Functions
    {
        #region ANGLE_CALCULATIONS_INT

        /// <summary>
        /// This function calculates the sum of two angles in 360 degrees system
        /// </summary>
        /// <param name="Angle_1">Angle to add [0,1 degrees]</param>
        /// <param name="Angle_2">Angle to add [0,1 degrees]</param>
        /// <returns>Sum of the two angles in 360 degrees system [0,1 degrees]</returns>
        public static int CalcAngleSum(int Angle_1, int Angle_2)
        {
            int result = Angle_1 + Angle_2;
            if (result > 3599) result -= 3600;
            else if (result < 0) result += 3600;

            return result;
        }

        /// <summary>
        /// This function handles subtraction of two angles in 360 degrees system
        /// </summary>
        /// <param name="Angle_1">Angle to subtract from [0,1 degrees]</param>
        /// <param name="Angle_2">Angle to subtract [0,1 degrees]</param>
        /// <returns>Result of subtraction in 360 degrees system [0,1 degrees]</returns>
        public static int CalcAngleSubtract(int Angle_1, int Angle_2)
        {
            int result = Angle_1 - Angle_2;
            if (result > 3599) result -= 3600;
            else if (result < 0) result += 3600;

            return result;
        }

        /// <summary>
        /// This function returns the angle distance/difference between two angles in 360 degrees system.
        /// The result never exceeds 180 degrees.(distance to the left or right - smaller will be returned)
        /// Compares Angle_2 relative to Angle_1
        /// </summary>
        /// <param name="Angle_1">Angle to subtract from [0,1 degrees]</param>
        /// <param name="Angle_2">Angle to subtract [0,1 degrees]</param>
        /// <returns>Difference between angles. Positive when Angle_2 > Angle_1 and negative when Angle_1 > Angle_2 [0,1 degrees]</returns>
        public static int CalcAngleDistanceBetween(int Angle_1, int Angle_2)
        {
            int result_1 = CalcAngleSubtract(Angle_1, Angle_2);
            int result_2 = CalcAngleSubtract(Angle_2, Angle_1);

            if (result_1 < result_2) return -result_1;
            else return result_2;
        }

        #endregion ANGLE_CALCULATIONS_INT


        #region ANGLE_CALCULATIONS_FLOAT

        /// <summary>
        /// This function calculates the sum of two angles in 360 degrees system
        /// </summary>
        /// <param name="Angle_1">Angle to add [0,1 degrees]</param>
        /// <param name="Angle_2">Angle to add [0,1 degrees]</param>
        /// <returns>Sum of the two angles in 360 degrees system [0,1 degrees]</returns>
        public static float CalcAngleSum(float Angle_1, float Angle_2)
        {
            float result = Angle_1 + Angle_2;
            if (result > 359.9) result -= 360;
            else if (result < 0) result += 360;

            return result;
        }

        /// <summary>
        /// This function handles subtraction of two angles in 360 degrees system
        /// </summary>
        /// <param name="Angle_1">Angle to subtract from [0,1 degrees]</param>
        /// <param name="Angle_2">Angle to subtract [0,1 degrees]</param>
        /// <returns>Result of subtraction in 360 degrees system [0,1 degrees]</returns>
        public static float CalcAngleSubtract(float Angle_1, float Angle_2)
        {
            float result = Angle_1 - Angle_2;
            if (result > 359.99) result -= 360;
            else if (result < 0) result += 360;

            return result;
        }

        /// <summary>
        /// This function returns the angle distance/difference between two angles in 360 degrees system.
        /// The result never exceeds 180 degrees.(distance to the left or right - smaller will be returned)
        /// Compares Angle_2 relative to Angle_1
        /// </summary>
        /// <param name="Angle_1">Angle to subtract from [0,1 degrees]</param>
        /// <param name="Angle_2">Angle to subtract [0,1 degrees]</param>
        /// <returns>Difference between angles. Positive when Angle_2 > Angle_1 and negative when Angle_1 > Angle_2 [0,1 degrees]</returns>
        public static float CalcAngleDistanceBetween(float Angle_1, float Angle_2)
        {
            float result_1 = CalcAngleSubtract(Angle_1, Angle_2);
            float result_2 = CalcAngleSubtract(Angle_2, Angle_1);

            if (result_1 < result_2) return -result_1;
            else return result_2;
        }

        #endregion ANGLE_CALCULATIONS_INT
    }


    // custom FiFo List function for defined amount of values
    public class FiFoList : List<string>
    {
        int max;

        public FiFoList(int capacity)
        {
            max = capacity;
        }

        //public new string this[int index]
        //{
        //    get
        //    {
        //        return (string)base[index];
        //    }
        //    set
        //    {
        //        base[index] = "(" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ") " + value;
        //    }
        //}
        public new void Add(string Text)
        {
            if (base.Count >= max)
                base.RemoveAt(0);
            base.Add(Text);
        }
        public void Add_WithTime(string Text)
        {
            if (base.Count >= max)
                base.RemoveAt(0);
            base.Add("(" + DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2")
                + ":" + DateTime.Now.Second.ToString("D2") + ") - " + Text);
        }
    }


    // Log In dialog box
    public class LogInDialog
    {
        public System.Windows.Forms.DialogResult ShowDialog(ref string User, ref string Password)
        {
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            System.Windows.Forms.Label label_User = new System.Windows.Forms.Label();
            System.Windows.Forms.Label label_Password = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox textBox_User = new System.Windows.Forms.TextBox();
            System.Windows.Forms.TextBox textBox_Password = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Button buttonOk = new System.Windows.Forms.Button();
            System.Windows.Forms.Button buttonCancel = new System.Windows.Forms.Button();

            form.Text = "Login";
            label_User.Text = "User";
            label_Password.Text = "Password";
            //textBox_User.Text = "";
            //textBox_Password.Text = "";

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            label_User.SetBounds(50, 23, 322, 13);
            label_Password.SetBounds(25, 53, 322, 13);
            textBox_User.SetBounds(80, 20, 150, 20);
            textBox_Password.SetBounds(80, 50, 150, 20);
            buttonOk.SetBounds(130, 85, 75, 23);
            buttonCancel.SetBounds(210, 85, 75, 23);

            textBox_Password.PasswordChar = '*';

            label_User.AutoSize = true;
            label_Password.AutoSize = true;

            form.ClientSize = new System.Drawing.Size(300, 120);
            form.Controls.AddRange(new System.Windows.Forms.Control[]{
                label_User,
                label_Password,
                textBox_User,
                textBox_Password,
                buttonOk,
                buttonCancel});
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            System.Windows.Forms.DialogResult dialogResult = form.ShowDialog();
            User = textBox_User.Text;
            Password = textBox_Password.Text;
            return dialogResult;
        }
    }


    static class Users
    {
        public static Users.UserLevel User_Level = Users.UserLevel.USER_LEVEL_0;

        public enum UserLevel
        {
            USER_LEVEL_0 = 0,
            USER_LEVEL_ADMIN = 1,
            USER_LEVEL_SERVICE = 2,
            USER_LEVEL_DEVELOPER = 10
        };
    }
}

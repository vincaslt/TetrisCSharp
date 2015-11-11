using System.Configuration;

namespace TetrisCS.Windows
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            var w = int.Parse(ConfigurationManager.AppSettings["Width"]);
            var h = int.Parse(ConfigurationManager.AppSettings["Height"]);
            components = new System.ComponentModel.Container();
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Text = "Tetris!";
            Name = "GameWindow";
            Size = new System.Drawing.Size(w, h);
        }

        #endregion
    }
}


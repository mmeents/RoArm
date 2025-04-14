namespace RoArmDriver.App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                _driver?.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      splitContainer1 = new SplitContainer();
      LableY = new Label();
      LabelTilt = new Label();
      tbZ = new TrackBar();
      LabelZ = new Label();
      lbY = new Label();
      tbY = new TrackBar();
      lbTilt = new Label();
      lbZ = new Label();
      tbTilt = new TrackBar();
      lbX = new Label();
      labelX = new Label();
      tbX = new TrackBar();
      lbStatus = new Label();
      lbLamp = new Label();
      label7 = new Label();
      tbLamp = new TrackBar();
      lbHand = new Label();
      lbRoll = new Label();
      lbWrist = new Label();
      lbElbow = new Label();
      lbShoulder = new Label();
      lbBase = new Label();
      label6 = new Label();
      label5 = new Label();
      label4 = new Label();
      label3 = new Label();
      label2 = new Label();
      Label01 = new Label();
      tbHand = new TrackBar();
      tbRoll = new TrackBar();
      tbWrist = new TrackBar();
      tbElbow = new TrackBar();
      tbShoulder = new TrackBar();
      tbBase = new TrackBar();
      edLog = new TextBox();
      debounceTimer = new System.Windows.Forms.Timer(components);
      ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)tbZ).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbY).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbTilt).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbX).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbLamp).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbHand).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbRoll).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbWrist).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbElbow).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbShoulder).BeginInit();
      ((System.ComponentModel.ISupportInitialize)tbBase).BeginInit();
      SuspendLayout();
      // 
      // splitContainer1
      // 
      splitContainer1.Dock = DockStyle.Fill;
      splitContainer1.Location = new Point(0, 0);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(LableY);
      splitContainer1.Panel1.Controls.Add(LabelTilt);
      splitContainer1.Panel1.Controls.Add(tbZ);
      splitContainer1.Panel1.Controls.Add(LabelZ);
      splitContainer1.Panel1.Controls.Add(lbY);
      splitContainer1.Panel1.Controls.Add(tbY);
      splitContainer1.Panel1.Controls.Add(lbTilt);
      splitContainer1.Panel1.Controls.Add(lbZ);
      splitContainer1.Panel1.Controls.Add(tbTilt);
      splitContainer1.Panel1.Controls.Add(lbX);
      splitContainer1.Panel1.Controls.Add(labelX);
      splitContainer1.Panel1.Controls.Add(tbX);
      splitContainer1.Panel1.Controls.Add(lbStatus);
      splitContainer1.Panel1.Controls.Add(lbLamp);
      splitContainer1.Panel1.Controls.Add(label7);
      splitContainer1.Panel1.Controls.Add(tbLamp);
      splitContainer1.Panel1.Controls.Add(lbHand);
      splitContainer1.Panel1.Controls.Add(lbRoll);
      splitContainer1.Panel1.Controls.Add(lbWrist);
      splitContainer1.Panel1.Controls.Add(lbElbow);
      splitContainer1.Panel1.Controls.Add(lbShoulder);
      splitContainer1.Panel1.Controls.Add(lbBase);
      splitContainer1.Panel1.Controls.Add(label6);
      splitContainer1.Panel1.Controls.Add(label5);
      splitContainer1.Panel1.Controls.Add(label4);
      splitContainer1.Panel1.Controls.Add(label3);
      splitContainer1.Panel1.Controls.Add(label2);
      splitContainer1.Panel1.Controls.Add(Label01);
      splitContainer1.Panel1.Controls.Add(tbHand);
      splitContainer1.Panel1.Controls.Add(tbRoll);
      splitContainer1.Panel1.Controls.Add(tbWrist);
      splitContainer1.Panel1.Controls.Add(tbElbow);
      splitContainer1.Panel1.Controls.Add(tbShoulder);
      splitContainer1.Panel1.Controls.Add(tbBase);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(edLog);
      splitContainer1.Size = new Size(905, 869);
      splitContainer1.SplitterDistance = 479;
      splitContainer1.TabIndex = 0;
      // 
      // LableY
      // 
      LableY.AutoSize = true;
      LableY.Location = new Point(12, 504);
      LableY.Name = "LableY";
      LableY.Size = new Size(63, 20);
      LableY.TabIndex = 33;
      LableY.Text = "Y Range";
      // 
      // LabelTilt
      // 
      LabelTilt.AutoSize = true;
      LabelTilt.Location = new Point(30, 450);
      LabelTilt.Name = "LabelTilt";
      LabelTilt.Size = new Size(30, 20);
      LabelTilt.TabIndex = 32;
      LabelTilt.Text = "Tilt";
      // 
      // tbZ
      // 
      tbZ.Location = new Point(235, 548);
      tbZ.Maximum = 500;
      tbZ.Name = "tbZ";
      tbZ.Orientation = Orientation.Vertical;
      tbZ.Size = new Size(56, 265);
      tbZ.TabIndex = 31;
      tbZ.TickFrequency = 15;
      tbZ.TickStyle = TickStyle.Both;
      // 
      // LabelZ
      // 
      LabelZ.AutoSize = true;
      LabelZ.Location = new Point(165, 567);
      LabelZ.Name = "LabelZ";
      LabelZ.Size = new Size(64, 20);
      LabelZ.TabIndex = 30;
      LabelZ.Text = "Z Range";
      // 
      // lbY
      // 
      lbY.AutoSize = true;
      lbY.Location = new Point(360, 536);
      lbY.Name = "lbY";
      lbY.Size = new Size(30, 20);
      lbY.TabIndex = 29;
      lbY.Text = "lbY";
      // 
      // tbY
      // 
      tbY.Location = new Point(89, 500);
      tbY.Maximum = 200;
      tbY.Minimum = -200;
      tbY.Name = "tbY";
      tbY.Size = new Size(265, 56);
      tbY.TabIndex = 28;
      tbY.TickFrequency = 15;
      tbY.TickStyle = TickStyle.Both;
      // 
      // lbTilt
      // 
      lbTilt.AutoSize = true;
      lbTilt.Location = new Point(360, 450);
      lbTilt.Name = "lbTilt";
      lbTilt.Size = new Size(43, 20);
      lbTilt.TabIndex = 27;
      lbTilt.Text = "lbTilt";
      // 
      // lbZ
      // 
      lbZ.AutoSize = true;
      lbZ.Location = new Point(360, 567);
      lbZ.Name = "lbZ";
      lbZ.Size = new Size(31, 20);
      lbZ.TabIndex = 26;
      lbZ.Text = "lbZ";
      // 
      // tbTilt
      // 
      tbTilt.Location = new Point(89, 440);
      tbTilt.Maximum = 360;
      tbTilt.Name = "tbTilt";
      tbTilt.Size = new Size(265, 56);
      tbTilt.TabIndex = 25;
      tbTilt.TickFrequency = 15;
      tbTilt.TickStyle = TickStyle.Both;
      // 
      // lbX
      // 
      lbX.AutoSize = true;
      lbX.Location = new Point(360, 504);
      lbX.Name = "lbX";
      lbX.Size = new Size(31, 20);
      lbX.TabIndex = 24;
      lbX.Text = "lbX";
      // 
      // labelX
      // 
      labelX.AutoSize = true;
      labelX.Location = new Point(29, 567);
      labelX.Name = "labelX";
      labelX.Size = new Size(64, 20);
      labelX.TabIndex = 23;
      labelX.Text = "X Range";
      // 
      // tbX
      // 
      tbX.Location = new Point(103, 548);
      tbX.Maximum = 400;
      tbX.Name = "tbX";
      tbX.Orientation = Orientation.Vertical;
      tbX.Size = new Size(56, 265);
      tbX.TabIndex = 22;
      tbX.TickFrequency = 15;
      tbX.TickStyle = TickStyle.Both;
      // 
      // lbStatus
      // 
      lbStatus.AutoSize = true;
      lbStatus.Location = new Point(24, 27);
      lbStatus.Name = "lbStatus";
      lbStatus.Size = new Size(85, 20);
      lbStatus.TabIndex = 21;
      lbStatus.Text = "LabelStatus";
      // 
      // lbLamp
      // 
      lbLamp.AutoSize = true;
      lbLamp.Location = new Point(360, 75);
      lbLamp.Name = "lbLamp";
      lbLamp.Size = new Size(58, 20);
      lbLamp.TabIndex = 20;
      lbLamp.Text = "label12";
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Location = new Point(25, 75);
      label7.Name = "label7";
      label7.Size = new Size(46, 20);
      label7.TabIndex = 19;
      label7.Text = "Lamp";
      // 
      // tbLamp
      // 
      tbLamp.Location = new Point(89, 62);
      tbLamp.Maximum = 250;
      tbLamp.Name = "tbLamp";
      tbLamp.Size = new Size(265, 56);
      tbLamp.TabIndex = 18;
      tbLamp.TickFrequency = 15;
      tbLamp.TickStyle = TickStyle.Both;
      // 
      // lbHand
      // 
      lbHand.AutoSize = true;
      lbHand.Location = new Point(360, 126);
      lbHand.Name = "lbHand";
      lbHand.Size = new Size(58, 20);
      lbHand.TabIndex = 17;
      lbHand.Text = "label12";
      // 
      // lbRoll
      // 
      lbRoll.AutoSize = true;
      lbRoll.Location = new Point(360, 173);
      lbRoll.Name = "lbRoll";
      lbRoll.Size = new Size(58, 20);
      lbRoll.TabIndex = 16;
      lbRoll.Text = "label11";
      // 
      // lbWrist
      // 
      lbWrist.AutoSize = true;
      lbWrist.Location = new Point(360, 232);
      lbWrist.Name = "lbWrist";
      lbWrist.Size = new Size(58, 20);
      lbWrist.TabIndex = 15;
      lbWrist.Text = "label10";
      // 
      // lbElbow
      // 
      lbElbow.AutoSize = true;
      lbElbow.Location = new Point(360, 276);
      lbElbow.Name = "lbElbow";
      lbElbow.Size = new Size(50, 20);
      lbElbow.TabIndex = 14;
      lbElbow.Text = "label9";
      // 
      // lbShoulder
      // 
      lbShoulder.AutoSize = true;
      lbShoulder.Location = new Point(360, 330);
      lbShoulder.Name = "lbShoulder";
      lbShoulder.Size = new Size(50, 20);
      lbShoulder.TabIndex = 13;
      lbShoulder.Text = "label8";
      // 
      // lbBase
      // 
      lbBase.AutoSize = true;
      lbBase.Location = new Point(360, 380);
      lbBase.Name = "lbBase";
      lbBase.Size = new Size(50, 20);
      lbBase.TabIndex = 12;
      lbBase.Text = "label7";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Location = new Point(25, 126);
      label6.Name = "label6";
      label6.Size = new Size(45, 20);
      label6.TabIndex = 11;
      label6.Text = "Hand";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(25, 173);
      label5.Name = "label5";
      label5.Size = new Size(35, 20);
      label5.TabIndex = 10;
      label5.Text = "Roll";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(25, 232);
      label4.Name = "label4";
      label4.Size = new Size(43, 20);
      label4.TabIndex = 9;
      label4.Text = "Wrist";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(25, 276);
      label3.Name = "label3";
      label3.Size = new Size(50, 20);
      label3.TabIndex = 8;
      label3.Text = "Elbow";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(25, 330);
      label2.Name = "label2";
      label2.Size = new Size(68, 20);
      label2.TabIndex = 7;
      label2.Text = "Shoulder";
      // 
      // Label01
      // 
      Label01.AutoSize = true;
      Label01.Location = new Point(25, 380);
      Label01.Name = "Label01";
      Label01.Size = new Size(40, 20);
      Label01.TabIndex = 6;
      Label01.Text = "Base";
      // 
      // tbHand
      // 
      tbHand.Location = new Point(89, 113);
      tbHand.Maximum = 180;
      tbHand.Name = "tbHand";
      tbHand.Size = new Size(265, 56);
      tbHand.TabIndex = 5;
      tbHand.TickFrequency = 15;
      tbHand.TickStyle = TickStyle.Both;
      // 
      // tbRoll
      // 
      tbRoll.Location = new Point(89, 164);
      tbRoll.Maximum = 180;
      tbRoll.Minimum = -180;
      tbRoll.Name = "tbRoll";
      tbRoll.Size = new Size(265, 56);
      tbRoll.TabIndex = 4;
      tbRoll.TickFrequency = 30;
      tbRoll.TickStyle = TickStyle.Both;
      // 
      // tbWrist
      // 
      tbWrist.Location = new Point(89, 215);
      tbWrist.Maximum = 100;
      tbWrist.Minimum = -100;
      tbWrist.Name = "tbWrist";
      tbWrist.Size = new Size(265, 56);
      tbWrist.TabIndex = 3;
      tbWrist.TickFrequency = 15;
      tbWrist.TickStyle = TickStyle.Both;
      // 
      // tbElbow
      // 
      tbElbow.Location = new Point(89, 266);
      tbElbow.Maximum = 180;
      tbElbow.Minimum = -70;
      tbElbow.Name = "tbElbow";
      tbElbow.Size = new Size(265, 56);
      tbElbow.TabIndex = 2;
      tbElbow.TickFrequency = 15;
      tbElbow.TickStyle = TickStyle.Both;
      // 
      // tbShoulder
      // 
      tbShoulder.Location = new Point(89, 317);
      tbShoulder.Maximum = 180;
      tbShoulder.Minimum = -70;
      tbShoulder.Name = "tbShoulder";
      tbShoulder.Size = new Size(265, 56);
      tbShoulder.TabIndex = 1;
      tbShoulder.TickFrequency = 15;
      tbShoulder.TickStyle = TickStyle.Both;
      // 
      // tbBase
      // 
      tbBase.Location = new Point(89, 367);
      tbBase.Maximum = 180;
      tbBase.Minimum = -180;
      tbBase.Name = "tbBase";
      tbBase.Size = new Size(265, 56);
      tbBase.TabIndex = 0;
      tbBase.TickFrequency = 30;
      tbBase.TickStyle = TickStyle.Both;
      // 
      // edLog
      // 
      edLog.Dock = DockStyle.Fill;
      edLog.Location = new Point(0, 0);
      edLog.Multiline = true;
      edLog.Name = "edLog";
      edLog.Size = new Size(422, 869);
      edLog.TabIndex = 0;
      // 
      // debounceTimer
      // 
      debounceTimer.Interval = 600;
      debounceTimer.Tick += debounceTimer_Tick;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(8F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(905, 869);
      Controls.Add(splitContainer1);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "Form1";
      Text = "RoArm.Runner";
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel1.PerformLayout();
      splitContainer1.Panel2.ResumeLayout(false);
      splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
      splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)tbZ).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbY).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbTilt).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbX).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbLamp).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbHand).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbRoll).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbWrist).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbElbow).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbShoulder).EndInit();
      ((System.ComponentModel.ISupportInitialize)tbBase).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private TextBox edLog;
    private TrackBar tbShoulder;
    private TrackBar tbBase;
    private TrackBar tbRoll;
    private TrackBar tbWrist;
    private TrackBar tbElbow;
    private Label lbHand;
    private Label lbRoll;
    private Label lbWrist;
    private Label lbElbow;
    private Label lbShoulder;
    private Label lbBase;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label Label01;
    private TrackBar tbHand;
    private Label lbLamp;
    private Label label7;
    private TrackBar tbLamp;
    private System.Windows.Forms.Timer debounceTimer;
    private Label lbStatus;
    private Label LableY;
    private Label LabelTilt;
    private TrackBar tbZ;
    private Label LabelZ;
    private Label lbY;
    private TrackBar tbY;
    private Label lbTilt;
    private Label lbZ;
    private TrackBar tbTilt;
    private Label lbX;
    private Label labelX;
    private TrackBar tbX;
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Training119Helper;

namespace Training119
{
    public partial class MainForm : Form
    {
        //const int _SERIAL = 1518181;
        string _SERIAL = HashHelper.GetConfigSerialNo();
        #region define com param

        //
        // Event Define
        // 事件类型定义.同步与系统发出的消息,请选择其中一种方式处理
        //
        const int TEvent_InterOffHook = 0; // 本地电话机摘机事件

        //TV_Event.data.dataResult
        // 0 摘机
        // 1 挂机 
        const int TEvent_PcDoHook = 1; // 本地调用TV_OffHookCtrl软摘机或TV_HangUpCtrl软挂机成功

        //TV_Event.data.ptrData='1' 为一声震铃结束
        //其它为开始震铃
        //TV_Event.data.dataResult震铃次数
        const int TEvent_Ring = 3; // 外线通道振铃事件

        const int TEvent_DialEnd = 4; // 系统拨号拨号结束事件,(调用TV_StartDial(...)拨号完成了)

        //TEvent.data.ptrData[0]=0为单文件播放结束
        //TEvent.data.ptrData[0]=1为多文件连播结束，返回最后一个文件播放的ID
        const int TEvent_PlayEnd = 5; // 放音结束事件

        const int TEvent_NoPSTNLine = 6; //没有接入PSTN外线，当调用TV_OffHookCtrl(...)，让设备摘机后如果没有接入PSTN就触发该消息

        const int TEvent_SendCallIDEnd = 7; //发送震铃的号码结束(适用A2，B2)

        const int TEvent_Silence = 9; //通话是一定时间的静音.默认为8秒

        //收到DTMF码事件
        //如果是在电脑摘机TV_OffHookCtrl后需要接受对方按键，建议设置录音方式会TV_SetRecSource(RS_SPK)
        const int TEvent_GetChar = 10; // 收到DTMF码事件


        // 拨号后,被叫方摘机事件
        //Result:1、3传统方式检测到
        //Result:2使用检测彩铃方式检测到
        //Result:4:使用级性反转方式检测到
        //对每次拨号系统只提示一次
        //
        //注意：建议不要使用，该事件不会100%准确，特使在手机彩铃条件下不能准确的检测该事件
        //没有检测到对方摘机，挂断时就提示忙音事件
        const int TEvent_OffHook = 11;

        //对方挂机事件,在一次通话时没有检测到对方摘机事件时(TEvent_OffHook),该事件不触发,只触发TEvent_Busy事件
        //建议同时处理TEvent_HangUp和TEvent_Busy表示对方终止通话
        //
        const int TEvent_HangUp = 12;

        const int TEvent_Nobody = 13; // 拨号后,没人接听事件

        const int TEvent_Busy = 14; // 检测到忙音事件

        const int TEvent_InterHangUp = 19; // 本地电话机挂机

        const int TEvent_Dial = 28; //检测到拨号音

        const int TEvent_TelDial = 29; //检测到话机拨号DTMF码

        const int TEvent_GetFsk = 30; //得到FSK来电

        const int TEvent_StopCallIn = 31; //对方停止呼叫，（产生一个未接电话）

        const int TEvent_GetDTMF = 32; //得到DTMF码来电

        const int TEvent_TelCallOut = 33; //电话机呼出。也就电话机拨号后听到回铃音

        const int TEvent_RingBack = 34; //电脑拨号后接受到回铃音了

        const int TEvent_PlugOut = 36; //设备被拔掉

        const int TEvent_PlugIn = 37; //设备插入

        const int TEvent_RecordError = 38; //录音发生错误(建议重新初始化设备)

        const int TEvent_PlayError = 39; //播放错误(建议重新初始化设备)

        const int TEvent_GetDTMFTimeOut = 40; //接收DTMF来电超时（未震铃）。

        const int TEvent_MicIn = 41; //MIC插入状态,只支持玻瑞器B系列

        const int TEvent_MicOut = 42; //MIC拔出状态,只支持玻瑞器B系列

        //(调用TV_StartFlash后达到指定的时间就完成一个FLASH),不是用户按电话机的拍插簧动作
        //接受到该消息后可以调用TV_StartDial(...)进行转分机操作
        const int TEvent_FlashEnd = 43; //拍插簧(Flash)完成

        const int TEvent_GetSpeech = 44;

        const long RS_MIC = 0;
        const long RS_DOID = 1;
        const long RS_SPKDOID = 2;
        const long RS_SPK = 3;

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_GetEvent(ref TEvent ee);
        [DllImport("TmA4Drv.dll")]
        public static extern void TV_EnableCryptOfSerial(bool bEnable);

        [DllImport("TmA4Drv.dll")]
        public static extern double TV_SetDTMFParam(int nFlow, int nSlow, double nValue, int nNum);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_Initialize();

        [DllImport("TmA4Drv.dll")]
        public static extern int Tma4drv_DLL_Version(string code);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_OpenDoPlay();

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_CloseDoPlay();

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_ReInit();

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_Disable();

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_OffHookDetect(int Channel);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_RingDetect(int Channel);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_OffHookCtrl();

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_HangUpCtrl();

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetSendDTMFSpeed(int speed);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_StartDialEx(string code, bool st, bool stl);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_StopDial();

        [DllImport("TmA4Drv.dll")]
        public static extern int VS_GetSigFreq(string ProcessBuf, int nBufLen);

        [DllImport("TmA4Drv.dll")]
        public static extern bool VS_SetSigFreq(int freq, int freq1, int ID);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_StartPlayFile(string fname, int fseek, int num, bool bOpenPlay, bool bReplay, bool bSetVolume, int bTimeout);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_StopPlayFile(int nDevID);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_StartRecordFile(string fname, int fseek, int num);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_StopRecordFile(int nDevID, bool bClearBusy);

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_GetInitState();

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetVolume(int iLevel, int iType);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_GetVolume(int iType);

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_GetTelState();

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_GetPcState();

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_IsTalkState();

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_CheckDialSignal();

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetLocalTelSpeed(int iTelSpeed, bool bType);

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_DialRest();

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_GetSerial(string serial);

        [DllImport("TmA4Drv.dll")]
        public static extern ulong TV_GetSerial2();

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_GetLastError();

        [DllImport("TmA4Drv.dll")]
        public static extern int TV_ClearEvent();

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_EnableSoftWare(bool bEnable);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_EnableRing(bool bEnable);
        //设置检测DTMF的灵敏度
        //     iLevel:0                最灵敏
        //     iLevel:1                灵敏
        //     iLevel:2                中等
        //     iLevel:3                低
        //     iLevel:4                最低
        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetCheckDTMFLevel(int nLevel);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetDialVolLevel(int nLevel);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetBusyNum(int nBusyNum);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetSileLength(int nSileLength);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetOffHookType(bool bType);

        [DllImport("TmA4Drv.dll")]
        public static extern long TV_GetSoundRecordFilePath(string pOutBuf, int iLen);

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_IsMicSpkEnable();

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_EnableMicSpk(bool bEnable);
        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_EnableMic(bool bEnable);

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_RegRecBufWnd(IntPtr handle);

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_RegMsgWnd(IntPtr hWnd, bool bType);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_SetRecSource(long iRecType);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_EnableEchoCanceller(bool xx);

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_SetCheckRingBackCodeNum(long codeNum);

        [DllImport("TmA4Drv.dll")]
        public static extern long TV_InitPlay();

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_SetSpeechNameList(string content);

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_StartSpeechDist(uint level);

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_StopSpeechDist();

        [DllImport("TmA4Drv.dll")]
        public static extern string TV_GetSpeechResult(int index);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_OpenPlayToTel();

        [DllImport("TmA4Drv.dll")]
        public static extern bool TV_IsPlayToTelOpen();

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_ClosePlayToTel();

        [DllImport("TmA4Drv.dll")]
        public static extern long TV_PlayFileRest(long lDevID);

        [DllImport("TmA4Drv.dll")]
        public static extern void TV_CloseLinePlay();



        [StructLayout(LayoutKind.Sequential)]
        public struct TEvent
        {
            public int EventType;
            public EDATA Data;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct EDATA
        {
            public int Result;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 46)]
            public byte[] Buf;
        }
        #endregion

        bool bOpen;
        int nPlayDevID = 0;
        int nRecDevID;
        bool ifDialing;
        string strFname;
        TEvent ee;
        DateTime CallBeginTime;
        bool isHang;
        string SoundBasePath = @"Wav\";
        string TelNo;
        string stateId;
        VideoWork vw;
        uint talkCount;
        string serial = string.Empty;


        private const int HEIGHT = 768;
        private const int WIDTH = 1024;
        private bool isPlay = false;
        private DateTime playTime=DateTime.Now;
        private int currentTimeSpan;

        private string[] flashList = new string[] { "main.swf", "", };
        private TimeSpan[] spanList = new TimeSpan[] { new TimeSpan(0, 0, 5), new TimeSpan(0, 0, 23) };
        public MainForm()
        {
            InitializeComponent();
            Cursor.Hide();
        }


        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = false;

#else
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
#endif
            pnlMain.Width = WIDTH;
            pnlMain.Height = HEIGHT;
            picMain.Height = HEIGHT;
            picMain.Width = WIDTH;
            flBegin.Height = HEIGHT;
            flBegin.Width = WIDTH;
            picMain.Load(@"pic\main.jpg");
            picMain.Visible = false;
            pnlMain.Left = (this.Width - pnlMain.Width) / 2;
            pnlMain.Top = (this.Height - pnlMain.Height) / 2;

            
            flAnswer.Visible = false;
            flFire.Visible = false;
            flBegin.Loop = false;
            playTime = DateTime.Now;
            flBegin.Movie = Application.StartupPath + @"\flash\main.swf";
            stateId = "PFM";
            Debug.WriteLine(flBegin.Width + ":" + flBegin.Left);
            picMain.Focus();     
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {

        }

        private void axShockwaveFlash1_OnReadyStateChange(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_OnReadyStateChangeEvent e)
        {

        }

        #region Action

        private void OpenDevice()
        {
            Tma4drv_DLL_Version("http://www.quanova.com");
            if (TV_Initialize() == 1)
            {
                TV_EnableCryptOfSerial(false);
                serial =((int)TV_GetSerial2()).ToString();
                //serial = _SERIAL;7
                //todo:change serial
                if (HashHelper.Hash(serial) != _SERIAL)
                //if (DateTime.Now > new DateTime(2010, 12, 30))
                {
                    CloseDevice();
                    timer1.Enabled = false;
                    MessageBox.Show("请使用配套语音盒！");
                    this.Close();
                    return;
                }
                ShowMsg("初始化设备成功");
                bOpen = true;
                
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("初始化设备失败，请重新启动程序！");
                bOpen = false;                
                this.Close();
            }
        }
        private void ShowMsg(string ms)
        {
            Debug.WriteLine(ms);
        }

        private void CloseDevice()
        {
            if (bOpen)
            {
                TV_ClosePlayToTel();
                TV_Disable();
                bOpen = false;
            }
        }

        private void OpenSpeaker()
        {
            if (!bOpen)
            {
                OpenDevice();
            }

            TV_OpenDoPlay();
        }

        private void CloseSpeaker()
        {
            if (bOpen)
            {
                TV_CloseDoPlay();
            }
        }


        private void EndTalk()
        {
            ifDialing = false;
            if (TV_DialRest() == 1)
                TV_StopDial();
            if (TV_GetTelState())//本地话机摘挂机状态
                HangUp();
            TV_EnableMicSpk(false);
            TV_EnableMic(false);
            if (nRecDevID >= 0)
            {
                TV_StopRecordFile(nRecDevID, false);
                nRecDevID = -1;
            }
        }
        private void HangUp()//挂机
        {
            if (bOpen)
            {
                TV_HangUpCtrl();
                ShowMsg("挂机");
            }
        }
        #endregion
        DateTime BeginRecog = DateTime.Now;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(stateId == "PFM")
                ShowMsg(playTime.ToString()+":"+DateTime.Now.ToString()+":" + (DateTime.Now.Subtract(playTime) > new TimeSpan(0, 0, 3)).ToString());
            try
            {
                //todo: flash time
#if DEBUG
                if (stateId == "PFM" && DateTime.Now.Subtract(playTime) > new TimeSpan(0, 0, 3))
#else
                if (stateId == "PFM" && DateTime.Now.Subtract(playTime) > new TimeSpan(0, 0, 23))
#endif
                {
                    PrepareTel();
                    flBegin.Stop();
                    picMain.Visible = true;
                    flBegin.Visible = false;
                    isPlay = false;
                    stateId = string.Empty;
                }
                else if (stateId == "PS" && TV_PlayFileRest(nPlayDevID) == 0)
                {
                    vw.Start();
                    flAnswer.Visible = true;
                    flAnswer.LoadMovie(0, Application.StartupPath + @"\flash\1.swf");
                    PlaySound("v1.wav");
                    flAnswer.GotoFrame(0);
                    flAnswer.Play();

                    picMain.Load(@"pic\bg1.jpg");
                    playTime = DateTime.Now;
                    stateId = "PFX";

                }
                else if (stateId == "PFX" && flAnswer.FrameNum == flAnswer.TotalFrames - 1)
                {
                    flAnswer.StopPlay();
                    if (TV_SetSpeechNameList("民主路华天大厦发生火灾,酒吧失火,我叫王明"))
                    {
                        if (!TV_StartSpeechDist(uint.Parse(System.Configuration.ConfigurationSettings.AppSettings["level"])))
                        {
                            ShowMsg("加载语音识别引擎失败");
                        }
                        else
                        {
                            lblCount.Text = "开始回答";
                            BeginRecog = DateTime.Now;
                            ShowMsg("加载语音识别引擎成功");
                        }
                    }
                    stateId = string.Empty;
                }
                else if (stateId == "PFTELOVER" && flAnswer.FrameNum == flAnswer.TotalFrames - 1)
                {
                    flAnswer.Visible = false;
                    picMain.Visible = false;
                    flBegin.Visible = true;
                    flFire.Visible = false;
                    vw.Stop();

                    flBegin.Movie = Application.StartupPath + @"\flash\5.swf";
                    PlaySound("v5.wav");
                    //todo: flas fram shoud be 0
                    flBegin.GotoFrame(0);//flAnswer.TotalFrames -10);
                    flBegin.Play();
                    stateId = "PF5";
                    //CloseDevice();
                }
                else if (stateId == "PF5" && flBegin.FrameNum >= flBegin.TotalFrames - 5)
                {
                    flBegin.GotoFrame(flBegin.TotalFrames - 1);
                    flBegin.Stop();
                    ResetTel();
                }
                else if (stateId == "RESET" && TV_PlayFileRest(nPlayDevID) == 0)
                {
                    ResetTel();
                }


                if (TV_GetInitState())
                {
                    if (TV_GetEvent(ref ee) > 0)
                    {
                        switch (ee.EventType)
                        {
                            case TEvent_GetFsk:
                                ShowMsg(fromasciibytearray(ee.Data.Buf));
                                break;
                            case TEvent_MicIn:
                                ShowMsg("麦克风插入");
                                break;
                            case TEvent_MicOut:
                                ShowMsg("麦克风拔出");
                                break;
                            case TEvent_OffHook:
                                ShowMsg("呼叫方摘机");
                                break;
                            case TEvent_Ring:
                                ShowMsg("来电响铃");
                                break;
                            case TEvent_DialEnd:
                                ShowMsg("拨号结束");
                                strFname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".wav";
                                nRecDevID = TV_StartRecordFile("c:\\0\\" + strFname, 0, 0);
                                CallBeginTime = DateTime.Now;
                                break;
                            case TEvent_Busy:
                                ShowMsg("忙音");
                                if (DateTime.Compare(CallBeginTime, DateTime.Now) > 6)
                                    EndTalk();
                                break;
                            case TEvent_PlayEnd:
                                ShowMsg("播放完毕");
                                break;
                            case TEvent_HangUp:
                                ShowMsg("对方挂机");
                                EndTalk();
                                break;
                            case TEvent_InterHangUp:
                                ShowMsg("本地话机挂机");
                                EndTalk();

                                ResetTel();
                                break;
                            case TEvent_InterOffHook:
                                ShowMsg("本地话机摘机");
                                PrepareTel();
                                //begin response
                                TelNo = string.Empty;
                                if (bOpen)
                                {
                                    TV_CloseDoPlay();
                                }
                                PlaySound("fengyin.wav");
                                //end response
                                isHang = true;
                                break;
                            case TEvent_Nobody:
                                ShowMsg("无人接听");
                                break;
                            case TEvent_GetChar:
                                StopPlay();
                                ShowMsg("取得DTMF码 " + fromasciibytearray(ee.Data.Buf));
                                if (TelNo == "119")
                                {
                                    break;
                                }
                                TelNo += fromasciibytearray(ee.Data.Buf).Substring(0, 1);
                                if (TelNo.Length >= 3 && TelNo != "119")
                                {
                                    PlaySound("bohaocuo.wav");
                                    TelNo = string.Empty;
                                    stateId = "RESET";
                                    break;
                                }
                                else if (TelNo == "119")
                                {
                                    BeginTel();
                                }
                                break;
                            case TEvent_TelDial:
                                //ShowMsg("本地话机拨号" + ee.Data.Buf.ToString());
                                ShowMsg("本地话机拨号" + fromasciibytearray(ee.Data.Buf));
                                break;
                            case TEvent_TelCallOut:
                                ShowMsg("本地话机拨号后听到回铃");
                                break;
                            case TEvent_GetSpeech:
                                string result = TV_GetSpeechResult(0);
                                ShowMsg("识别事件"); ShowMsg(result);
                                if (talkCount == 0 && result == "民主路华天大厦发生火灾")
                                {
                                    lblCount.Text = "";
                                    ShowMsg("民主路华天大厦发生火灾");
                                    flAnswer.Visible = true;
                                    //Thread.Sleep(2000);
                                    PlaySound("v2.wav");
                                    flAnswer.Movie = Application.StartupPath + @"\flash\2.swf";

                                    picMain.Load(@"pic\bg2.jpg");
                                    stateId = "PFX";
                                    TV_StopSpeechDist();
                                    talkCount++;
                                }
                                else if (talkCount == 1 && result == "酒吧失火")
                                {
                                    lblCount.Text = "";
                                    ShowMsg("酒吧失火");
                                    flAnswer.Visible = true;
                                    Thread.Sleep(1000);
                                    PlaySound("v3.wav");
                                    flAnswer.Movie = Application.StartupPath + @"\flash\3.swf";

                                    picMain.Load(@"pic\bg3.jpg");
                                    stateId = "PFX";
                                    TV_StopSpeechDist();
                                    talkCount++;
                                }
                                else if (talkCount == 2 && result == "我叫王明")
                                {
                                    lblCount.Text = "";
                                    TV_StopSpeechDist();
                                    ShowMsg("我叫王明");
                                    //timer1.Enabled = false;
                                    Thread.Sleep(3000);
                                    flAnswer.Visible = true; ;
                                    PlaySound("v4.wav");
                                    flAnswer.Movie = Application.StartupPath + @"\flash\4.swf";
                                    stateId = "PFTELOVER";
                                    talkCount = 0;
                                    //timer1.Enabled = true;
                                }
                                else
                                {
                                    lblCount.Text = "请重新回答";
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlaySound(string path)
        {
            path = @"wav\" + path;
            if (nPlayDevID >= 0)
            {
                TV_StopPlayFile(nPlayDevID);
                nPlayDevID = 0;
            }
            //todo: disable speaker
            nPlayDevID = TV_StartPlayFile(path, 0, 0, true, false, false, 0);
            if (nPlayDevID < 0)
            {
                Debug.WriteLine(path);
                throw new Exception(path);
            }
            ShowMsg("播放" + path);
        }

        private void StopPlay()
        {
            if (nPlayDevID >= 0)
            {
                TV_StopPlayFile(nPlayDevID);
                nPlayDevID = 0;
                ShowMsg("停止播放成功");
            }
        }

        public static string fromasciibytearray(byte[] characters)
        {

            ASCIIEncoding encoding = new ASCIIEncoding();
            string constructedstring = encoding.GetString(characters);
            return (constructedstring);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (bOpen)
            {
                TV_OffHookCtrl();
                System.Threading.Thread.Sleep(500);
                ShowMsg("摘机");
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (bOpen)
            {
                TV_HangUpCtrl();
                ShowMsg("挂机");
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (bOpen)
            {
                TV_HangUpCtrl();
                ShowMsg("停止拨号");
            }
        }

        private void PrepareTel()
        {
            OpenDevice();
            if (!TV_IsPlayToTelOpen())
            {
                TV_OpenPlayToTel();
            }

            IntPtr hanle = this.Handle;
            TV_RegMsgWnd(hanle, false);
            TV_EnableRing(false);
            TV_SetRecSource(RS_MIC);
            TV_EnableRing(false);
            TV_EnableEchoCanceller(true);
            TV_CloseDoPlay();
            TV_CloseLinePlay();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            TV_StopSpeechDist();
        }

        private void ResetTel()
        {
            CloseDevice();
            talkCount =0;
            if (vw != null)
            {
                vw.Stop();
            }
            vw = null;
            
            StopPlay();            
           // flBegin.Stop();            
            flAnswer.Stop();
            flAnswer.Visible = false;
            lblCount.Text = string.Empty;
            playTime = DateTime.Now;
            flBegin.Stop();
            stateId = "PFM";
            flBegin.Movie = Application.StartupPath + @"\flash\main.swf";
            flBegin.GotoFrame(1);
            flBegin.Play();
            
            
            flBegin.Visible = true;
            picMain.Visible = false;
            picMain.Load(@"pic\main.jpg");

            //picMain.Load(@"pic\main.jpg");
            //picMain.Visible = true;
            //flBegin.Visible = false;
            //flAnswer.Visible = false;
            flFire.Visible = false;         
            //PrepareTel();
        }

        private void BeginTel()
        {
            stateId = "PS";
            PlaySound("CallTalkRing.wav");
            picMain.Load(@"pic\bg.jpg");
            lblCount.Text = string.Empty;
           
            vw = new VideoWork(this.Handle, 81+(this.Width-pnlMain.Width)/2, 431+(this.Height-pnlMain.Height)/2, 325, 247);
        }

        private void tmPlay_Tick(object sender, EventArgs e)
        {

        }   

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Show();
        }
    }
}

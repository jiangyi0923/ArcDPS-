﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PlugIn_UpdateTool
{
    public delegate void 设置完成(ref bool ssu);
    public partial class Settingui : UserControl
    {
        public Settingui()
        {
            InitializeComponent();
            控件赋值();
        }

        private bool _设置完成 = false;

        public void 完成(ref bool ssu)
        {
            ssu = _设置完成;
        }

        //取消按钮
        private void Button1_Click(object sender, EventArgs e)
        {
            _设置完成 = true;
            Dispose();
        }
        //保存按钮
        private void Button4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            _设置完成 = true;
            Dispose();
        }
        //官网按钮
        private void Button2_Click(object sender, EventArgs e)
        {
            string 官方网址 = "https://gw2sy.top";
            Process.Start(官方网址);
        }
        //卸载按钮
        private void Button3_Click(object sender, EventArgs e)
        {

        }
        //检测环境
        private void Button5_Click(object sender, EventArgs e)
        {
            Testui testui = new Testui();
            Controls.Add(testui);
            testui.BringToFront();
        }

        private void 控件赋值()
        {
            checkBox1.Checked = Properties.Settings.Default.主程序;
            checkBox2.Checked = Properties.Settings.Default.db切换;
            checkBox3.Checked = Properties.Settings.Default.附加功能;
            checkBox4.Checked = Properties.Settings.Default.流动输出;
            checkBox5.Checked = Properties.Settings.Default.团队力学;
            checkBox6.Checked = Properties.Settings.Default.团队恩赐;
            checkBox7.Checked = Properties.Settings.Default.坐骑插件;
            checkBox8.Checked = Properties.Settings.Default.dx12;
            checkBox9.Checked = Properties.Settings.Default.r滤镜;
            checkBox10.Checked = Properties.Settings.Default.s滤镜;
            checkBox12.Checked = Properties.Settings.Default.启动更新;
            checkBox13.Checked = Properties.Settings.Default.自动启动;
            checkBox14.Checked = Properties.Settings.Default.跳过更新;
            checkBox15.Checked = Properties.Settings.Default.附加地图;
            checkBox16.Checked = Properties.Settings.Default.多线程下载;
            if (checkBox12.Checked)
            {
                checkBox14.Enabled = true;
            }
            else
            {
                checkBox14.Enabled = false;
            }
            if (checkBox7.Checked)
            {
                checkBox8.Enabled = true;
                checkBox9.Enabled = true;
                checkBox10.Enabled = true;
                if (checkBox8.Checked)
                {
                    checkBox10.Enabled = false;
                }
                if (checkBox9.Checked)
                {
                    checkBox10.Enabled = false;
                }
                if (checkBox10.Checked)
                {
                    checkBox8.Enabled = false;
                    checkBox9.Enabled = false;
                }
            }
            else
            {
                checkBox8.Enabled = false;
                checkBox9.Enabled = false;
                checkBox10.Enabled = false;
            }
            if (checkBox16.Checked)
            {
                numericUpDown1.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
            }
        }

        private void 按键事件(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            
            switch (int.Parse(check.Tag.ToString()))
            {
                case 2:
                    Properties.Settings.Default.db切换 = check.Checked;
                    break;
                case 3:
                    Properties.Settings.Default.附加功能 = check.Checked;
                    break;
                case 4:
                    Properties.Settings.Default.流动输出 = check.Checked;
                    if (check.Checked)
                    {
                        checkBox5.Enabled = false;
                        checkBox6.Enabled = false;
                    }
                    else
                    {
                        checkBox5.Enabled = true;
                        checkBox6.Enabled = true;
                    }
                    break;
                case 5:
                    Properties.Settings.Default.团队力学 = check.Checked;
                    if (check.Checked)
                    {
                        checkBox4.Enabled = false;
                    }
                    else
                    {
                        checkBox4.Enabled = true;
                    }
                    break;
                case 6:
                    Properties.Settings.Default.团队恩赐 = check.Checked;
                    if (check.Checked)
                    {
                        checkBox4.Enabled = false;
                    }
                    else
                    {
                        checkBox4.Enabled = true;
                    }
                    break;
                case 7:
                    Properties.Settings.Default.坐骑插件 = check.Checked;
                    if (check.Checked)
                    {
                        checkBox8.Enabled = true;
                        checkBox9.Enabled = true;
                        checkBox10.Enabled = true;
                    }
                    else
                    {
                        checkBox8.Enabled = false;
                        checkBox9.Enabled = false;
                        checkBox10.Enabled = false;
                        checkBox8.Checked = false;
                        checkBox9.Checked = false;
                        checkBox10.Checked = false;
                    }
                    break;
                case 8:
                    
                    if (checkBox7.Checked)
                    {
                        Properties.Settings.Default.dx12 = check.Checked;
                        if (check.Checked)
                        {
                            checkBox10.Enabled = false;
                        }
                        else
                        {
                            if (!checkBox9.Checked)
                            {
                                checkBox10.Enabled = true;
                            }
                        }
                    }

                    break;
                case 9:
                    if (checkBox7.Checked)
                    {
                        Properties.Settings.Default.r滤镜 = check.Checked;
                        if (check.Checked)
                        {
                            checkBox10.Enabled = false;
                        }
                        else
                        {
                            if (!checkBox8.Checked)
                            {
                                checkBox10.Enabled = true;
                            }
                            
                        }
                    }

                    break;
                case 10:
                    if (checkBox7.Checked)
                    {
                        Properties.Settings.Default.s滤镜 = check.Checked;
                        if (check.Checked)
                        {
                            checkBox8.Enabled = false;
                            checkBox9.Enabled = false;
                        }
                        else
                        {
                            checkBox8.Enabled = true;
                            checkBox9.Enabled = true;
                        }
                    }

                    break;
                case 12:
                    Properties.Settings.Default.启动更新 = check.Checked;
                    if (check.Checked)
                    {
                        checkBox14.Enabled = true;
                    }
                    else
                    {
                        checkBox14.Enabled = false;
                    }
                    break;
                case 13:
                    Properties.Settings.Default.自动启动 = check.Checked;
                    break;
                case 14:
                    Properties.Settings.Default.跳过更新 = check.Checked;
                    break;
                case 15:
                    Properties.Settings.Default.附加地图 = check.Checked;
                    break;
                case 16:
                    Properties.Settings.Default.多线程下载 = check.Checked;
                    if (check.Checked)
                    {
                        numericUpDown1.Enabled = true;
                    }
                    else
                    {
                        numericUpDown1.Enabled = false;
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
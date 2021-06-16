using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerAssembly
{
    public partial class Form1 : Form
    {
        public FormСonfigurator Сonfigurator { get; set; }
        public FormOrders Orders { get; set; }

        public Form1()
        {
            Сonfigurator = new FormСonfigurator();
            Orders = new FormOrders();

            InitializeComponent();

            Text = string.Empty;
            DoubleBuffered = true;
            var resolution = Screen.PrimaryScreen.Bounds.Size;
            Size = new Size(resolution.Width, resolution.Height);
            ClientSize = new Size(resolution.Width, resolution.Height);
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1200, 800);

            #region Panels 
            // Боковое меню
            var sideMenuPanel = new Panel();
            sideMenuPanel.BackColor = Color.FromArgb(31, 30, 68);
            sideMenuPanel.Dock = DockStyle.Left;
            sideMenuPanel.Location = new Point(0, 0);
            sideMenuPanel.Size = new Size(220, 642);
            // Используется для подсветки кнопок в боковом меню
            var panelIllumination = new Panel();
            panelIllumination.Size = new Size(7, 100);
            // Верхняя панелька
            var panelTitleBar = new Panel();
            panelTitleBar.BackColor = Color.FromArgb(26, 25, 62);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Size = new Size(1540, 75);
            // Панель начального меню
            var panelDesktop = new Panel();
            panelDesktop.BackColor = Color.FromArgb(34, 33, 74);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(220, 84);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1540, 558);
            panelDesktop.TabIndex = 3;
            #endregion

            #region IconPictureBox            
            // Иконка текущего меню


            var iconCurrentForm = new IconPictureBox();
            iconCurrentForm.BackColor = Color.FromArgb(26, 25, 62);
            iconCurrentForm.ForeColor = Color.MediumPurple;
            iconCurrentForm.IconColor = Color.MediumPurple;
            iconCurrentForm.IconFont = IconFont.Auto;
            iconCurrentForm.Location = new Point(42, 32);
            iconCurrentForm.Size = new Size(32, 32);
            #endregion
            // Название текущего меню
            var lblTitleChildForm = new Label();
            lblTitleChildForm.AutoSize = true;
            lblTitleChildForm.ForeColor = Color.Gainsboro;
            lblTitleChildForm.Location = new Point(80, 32);
            lblTitleChildForm.Size = new Size(45, 17);

            OpenHomeForm(this, lblTitleChildForm, iconCurrentForm);

            var welcomeButton = CreateHomeScreenButton("ПК для ПК \n Подбор хороших комплектующих для ПК :)");
            var welcomePicture = CreateWelcomeScreenIcon(panelDesktop.Width / 2 - 150, welcomeButton.Bottom, new Size(250, 240));
            welcomePicture.Image = Properties.Resources.logoPNGKR250px;

            // Логотип в верхнем левом углу
            var logo = CreateLogo(new Point(0, 0), new Size(220, 140));
            logo.Click += (sender, args) =>
            {
                OpenHomeForm(this, lblTitleChildForm, iconCurrentForm);
                welcomeButton.Visible = true;
                welcomePicture.Visible = true;
            };

            SizeChanged += (sender, args) =>
            {
                welcomePicture.Location = new Point(panelDesktop.Width / 2 - 150, welcomeButton.Bottom);
            };

            #region Buttons

            var btnConstructor = CreateButton(IconChar.LaptopCode, "Конфигуратор", logo.Bottom);
            var btnOrders = CreateButton(IconChar.StoreAlt, "Готовые сборки", btnConstructor.Bottom);
            var btnBasket = CreateButton(IconChar.ShoppingCart, "Корзина", btnOrders.Bottom);
            
            btnConstructor.Click += (Button, Color) =>
            {
                welcomeButton.Visible = false;
                welcomePicture.Visible = false;
                ActivateButton(sideMenuPanel, btnConstructor, btnOrders, panelIllumination, RGBColors.color1, iconCurrentForm);
                OpenChildForm(Сonfigurator, lblTitleChildForm, panelDesktop);
            };
                        
            btnOrders.Click += (Button, Color) =>
            {
                welcomeButton.Visible = false;
                welcomePicture.Visible = false;
                ActivateButton(sideMenuPanel, btnOrders, panelIllumination, RGBColors.color2, iconCurrentForm);
                OpenChildForm(Orders, lblTitleChildForm, panelDesktop);
            };         
            
            btnBasket.Click += (Button, Color) =>
            {
                welcomeButton.Visible = false;
                welcomePicture.Visible = false;
                ActivateButton(sideMenuPanel, btnBasket, btnOrders, panelIllumination, RGBColors.color3, iconCurrentForm);
                OpenBasketPanel(sideMenuPanel, Сonfigurator.BasketPanel, btnBasket, btnConstructor, panelIllumination, RGBColors.color1, iconCurrentForm);
                OpenChildForm(Сonfigurator, lblTitleChildForm, panelDesktop);
                
            };
            #endregion

            #region Controls
            panelDesktop.Controls.Add(welcomePicture);
            panelDesktop.Controls.Add(welcomeButton);

            panelTitleBar.Controls.Add(lblTitleChildForm);
            panelTitleBar.Controls.Add(iconCurrentForm);

            sideMenuPanel.Controls.Add(panelIllumination);
            sideMenuPanel.Controls.Add(btnBasket);
            sideMenuPanel.Controls.Add(btnOrders);
            sideMenuPanel.Controls.Add(btnConstructor);
            sideMenuPanel.Controls.Add(logo);

            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(sideMenuPanel);
            #endregion            
        }

        

        private PictureBox CreateWelcomeScreenIcon(int x, int y, Size size)
        {
            var pictureBox = new PictureBox();
            pictureBox.BackColor = Color.FromArgb(34, 33, 74);
            pictureBox.ForeColor = SystemColors.ControlText;
            pictureBox.Location = new Point(x, y);
            pictureBox.Name = "iconPictureBox1";
            pictureBox.Size = size;
            return pictureBox;
        }

        private Button CreateHomeScreenButton(string text)
        {
            var button = new Button();
            button.Dock = DockStyle.Top;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Microsoft Sans Serif", 25F);
            button.ForeColor = SystemColors.ButtonHighlight;
            button.Location = new Point(0, 0);
            button.Size = new Size(1, 130);
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            return button;
        }

        private IconButton CreateButton(IconChar iconChar, string text, int bottom)
        {
            var button = new IconButton();
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Microsoft Sans Serif", 10F);
            button.ForeColor = Color.Gainsboro;
            button.IconChar = iconChar;
            button.IconColor = Color.Gainsboro;
            button.IconFont = IconFont.Auto;
            button.IconSize = 32;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Location = new Point(0, bottom);
            button.Padding = new Padding(10, 0, 20, 0);
            button.Size = new Size(220, 100);
            button.Text = text;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.UseVisualStyleBackColor = true;
            return button;
        }

        private void OpenBasketPanel(Panel panelMenu, Panel basketPanel, IconButton btnBasket, IconButton btnConstructor, Panel panelIllumination, Color color,  IconPictureBox iconCurrentChildForm)
        {
            if (!basketPanel.Visible)
            {
                Сonfigurator.ShowPanel(Сonfigurator.BasketPanel);
                IlluminateButton(btnConstructor, panelIllumination, color);
            }
            else
            {
                ActivateButton(panelMenu, btnConstructor, panelIllumination, color, iconCurrentChildForm);
                Сonfigurator.HidePanel(Сonfigurator.BasketPanel);
            }
        }

        private void ActivateButton(Panel panelMenu, IconButton iconButton, Panel panelIllumination, Color color, IconPictureBox iconCurrentChildForm)
        {
            if (iconButton != null)
            {
                DisableButtons(panelMenu, iconButton);
                IlluminateButton(iconButton, panelIllumination, color);

                iconCurrentChildForm.IconChar = iconButton.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void ActivateButton(Panel panelMenu, IconButton iconButton, IconButton btnOrders, Panel panelIllumination, Color color, IconPictureBox iconCurrentChildForm)
        {
            if (iconButton != null)
            {
                DisableButton(btnOrders);
                IlluminateButton(iconButton, panelIllumination, color);

                iconCurrentChildForm.IconChar = iconButton.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void IlluminateButton(IconButton iconButton, Panel panelIllumination, Color color)
        {            
            iconButton.BackColor = Color.FromArgb(37, 36, 81);
            iconButton.ForeColor = color;
            iconButton.TextAlign = ContentAlignment.MiddleCenter;
            iconButton.IconColor = color;
            iconButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            iconButton.ImageAlign = ContentAlignment.MiddleRight;

            panelIllumination.BackColor = color;
            panelIllumination.Location = new Point(0, iconButton.Location.Y);
            panelIllumination.Visible = true;
            panelIllumination.BringToFront();
        }

        private void OpenChildForm(Form childForm, Label lblTitleChildForm, Panel panelDesktop)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void OpenHomeForm(Form homeForm, Label lblTitleHomeForm, IconPictureBox iconCurrentForm)
        {
            Сonfigurator.Visible = false;
            Orders.Visible = false;

            lblTitleHomeForm.Text = "Главный экран";
            lblTitleHomeForm.ForeColor = Color.Gainsboro;
            iconCurrentForm.IconChar = IconChar.Home;
            iconCurrentForm.BackColor = Color.FromArgb(26, 25, 62);
            iconCurrentForm.IconColor = Color.Blue;
        }

        private void DisableButton(IconButton btnOrders)
        {
            btnOrders.BackColor = Color.FromArgb(31, 30, 68);
            btnOrders.ForeColor = Color.Gainsboro;
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.IconColor = Color.Gainsboro;
            btnOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnOrders.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void DisableButtons(Panel panelMenu, IconButton iconButton)
        {
            foreach (var control in panelMenu.Controls)
            {
                if (control is IconButton && control != iconButton)
                {
                    var button = control as IconButton;
                    DisableButton(button);
                }
            }
        }

        private IconPictureBox CreateLogo(Point location, Size size)
        {
            var logo = new IconPictureBox();
            logo.BackColor = Color.FromArgb(31, 30, 68);
            logo.ForeColor = Color.FromArgb(24, 161, 251);
            logo.IconChar = IconChar.Laptop;
            logo.IconColor = Color.FromArgb(24, 161, 251);
            logo.IconFont = IconFont.Auto;
            logo.IconSize = 103;
            logo.Location = location;
            logo.Padding = new Padding(40, 0, 0, 0);
            logo.Size = size;
            logo.TabStop = false;
            return logo;
        }        

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
    }
}

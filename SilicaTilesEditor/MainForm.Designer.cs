
namespace SilicaTilesEditor
{
    partial class MainForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolMenu = new System.Windows.Forms.ToolStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.newItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.overlayLayerOption = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.tileset0 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileset1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileset2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileset3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileset4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileset5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileset6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tileset7 = new System.Windows.Forms.ToolStripMenuItem();
            this.lookingAt = new System.Windows.Forms.Label();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.selTileId = new System.Windows.Forms.Label();
            this.tileSelector = new SilicaTilesEditor.TileSelectorControl();
            this.tileList = new SilicaTilesEditor.TileMapEditorControl();
            this.toolMenu.SuspendLayout();
            this.layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolMenu
            // 
            this.toolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.layerMenu,
            this.tilesetMenu});
            this.toolMenu.Location = new System.Drawing.Point(0, 0);
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Size = new System.Drawing.Size(1107, 25);
            this.toolMenu.TabIndex = 0;
            this.toolMenu.Text = "MainMenu";
            // 
            // fileMenu
            // 
            this.fileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItem,
            this.loadItem,
            this.saveItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(38, 22);
            this.fileMenu.Text = "File";
            // 
            // newItem
            // 
            this.newItem.Name = "newItem";
            this.newItem.Size = new System.Drawing.Size(121, 22);
            this.newItem.Text = "New File";
            this.newItem.Click += new System.EventHandler(this.newItem_Click);
            // 
            // loadItem
            // 
            this.loadItem.Name = "loadItem";
            this.loadItem.Size = new System.Drawing.Size(121, 22);
            this.loadItem.Text = "Load File";
            this.loadItem.Click += new System.EventHandler(this.loadItem_Click);
            // 
            // saveItem
            // 
            this.saveItem.Name = "saveItem";
            this.saveItem.Size = new System.Drawing.Size(121, 22);
            this.saveItem.Text = "Save File";
            this.saveItem.Click += new System.EventHandler(this.saveItem_Click);
            // 
            // layerMenu
            // 
            this.layerMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.layerMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overlayLayerOption});
            this.layerMenu.Image = ((System.Drawing.Image)(resources.GetObject("layerMenu.Image")));
            this.layerMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerMenu.Name = "layerMenu";
            this.layerMenu.Size = new System.Drawing.Size(48, 22);
            this.layerMenu.Text = "Layer";
            // 
            // overlayLayerOption
            // 
            this.overlayLayerOption.Checked = true;
            this.overlayLayerOption.CheckOnClick = true;
            this.overlayLayerOption.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overlayLayerOption.Name = "overlayLayerOption";
            this.overlayLayerOption.Size = new System.Drawing.Size(145, 22);
            this.overlayLayerOption.Text = "Overlay Layer";
            this.overlayLayerOption.ToolTipText = "Enables the overlay layer";
            this.overlayLayerOption.Click += new System.EventHandler(this.overlayLayerOption_Click);
            // 
            // tilesetMenu
            // 
            this.tilesetMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tilesetMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileset0,
            this.tileset1,
            this.tileset2,
            this.tileset3,
            this.tileset4,
            this.tileset5,
            this.tileset6,
            this.tileset7});
            this.tilesetMenu.Image = ((System.Drawing.Image)(resources.GetObject("tilesetMenu.Image")));
            this.tilesetMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tilesetMenu.Name = "tilesetMenu";
            this.tilesetMenu.Size = new System.Drawing.Size(53, 22);
            this.tilesetMenu.Text = "Tileset";
            // 
            // tileset0
            // 
            this.tileset0.Checked = true;
            this.tileset0.CheckOnClick = true;
            this.tileset0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tileset0.Name = "tileset0";
            this.tileset0.Size = new System.Drawing.Size(146, 22);
            this.tileset0.Text = "NORM Tileset";
            this.tileset0.Click += new System.EventHandler(this.tileset0_Click);
            // 
            // tileset1
            // 
            this.tileset1.CheckOnClick = true;
            this.tileset1.Name = "tileset1";
            this.tileset1.Size = new System.Drawing.Size(146, 22);
            this.tileset1.Text = "SNOW Tileset";
            this.tileset1.Click += new System.EventHandler(this.tileset1_Click);
            // 
            // tileset2
            // 
            this.tileset2.CheckOnClick = true;
            this.tileset2.Name = "tileset2";
            this.tileset2.Size = new System.Drawing.Size(146, 22);
            this.tileset2.Text = "SAND Tileset";
            this.tileset2.Click += new System.EventHandler(this.tileset2_Click);
            // 
            // tileset3
            // 
            this.tileset3.CheckOnClick = true;
            this.tileset3.Name = "tileset3";
            this.tileset3.Size = new System.Drawing.Size(146, 22);
            this.tileset3.Text = "PIRT Tileset";
            this.tileset3.Click += new System.EventHandler(this.tileset3_Click);
            // 
            // tileset4
            // 
            this.tileset4.CheckOnClick = true;
            this.tileset4.Name = "tileset4";
            this.tileset4.Size = new System.Drawing.Size(146, 22);
            this.tileset4.Text = "FLWR Tileset";
            this.tileset4.Click += new System.EventHandler(this.tileset4_Click);
            // 
            // tileset5
            // 
            this.tileset5.CheckOnClick = true;
            this.tileset5.Name = "tileset5";
            this.tileset5.Size = new System.Drawing.Size(146, 22);
            this.tileset5.Text = "JNGL Tileset";
            this.tileset5.Click += new System.EventHandler(this.tileset5_Click);
            // 
            // tileset6
            // 
            this.tileset6.CheckOnClick = true;
            this.tileset6.Name = "tileset6";
            this.tileset6.Size = new System.Drawing.Size(146, 22);
            this.tileset6.Text = "CLWD Tileset";
            this.tileset6.Click += new System.EventHandler(this.tileset6_Click);
            // 
            // tileset7
            // 
            this.tileset7.CheckOnClick = true;
            this.tileset7.Name = "tileset7";
            this.tileset7.Size = new System.Drawing.Size(146, 22);
            this.tileset7.Text = "VOLC Tileset";
            this.tileset7.Click += new System.EventHandler(this.tileset7_Click);
            // 
            // lookingAt
            // 
            this.lookingAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lookingAt.AutoSize = true;
            this.lookingAt.Location = new System.Drawing.Point(126, 515);
            this.lookingAt.Name = "lookingAt";
            this.lookingAt.Size = new System.Drawing.Size(78, 13);
            this.lookingAt.TabIndex = 2;
            this.lookingAt.Text = "Looking at: 0,0";
            // 
            // layout
            // 
            this.layout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layout.ColumnCount = 2;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.tileSelector, 0, 0);
            this.layout.Controls.Add(this.tileList, 1, 0);
            this.layout.Location = new System.Drawing.Point(0, 22);
            this.layout.Margin = new System.Windows.Forms.Padding(0);
            this.layout.Name = "layout";
            this.layout.RowCount = 1;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 487F));
            this.layout.Size = new System.Drawing.Size(1107, 487);
            this.layout.TabIndex = 4;
            // 
            // selTileId
            // 
            this.selTileId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selTileId.AutoSize = true;
            this.selTileId.Location = new System.Drawing.Point(12, 515);
            this.selTileId.Name = "selTileId";
            this.selTileId.Size = new System.Drawing.Size(89, 13);
            this.selTileId.TabIndex = 5;
            this.selTileId.Text = "Seleted Tile ID: 0";
            // 
            // tileSelector
            // 
            this.tileSelector.AutoScroll = true;
            this.tileSelector.AutoScrollMinSize = new System.Drawing.Size(0, 1440);
            this.tileSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileSelector.Location = new System.Drawing.Point(3, 3);
            this.tileSelector.Name = "tileSelector";
            this.tileSelector.Size = new System.Drawing.Size(243, 481);
            this.tileSelector.TabIndex = 3;
            // 
            // tileList
            // 
            this.tileList.BackColor = System.Drawing.Color.Blue;
            this.tileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileList.Location = new System.Drawing.Point(252, 3);
            this.tileList.Name = "tileList";
            this.tileList.Size = new System.Drawing.Size(852, 481);
            this.tileList.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 537);
            this.Controls.Add(this.selTileId);
            this.Controls.Add(this.layout);
            this.Controls.Add(this.lookingAt);
            this.Controls.Add(this.toolMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Horse Isle Map Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolMenu.ResumeLayout(false);
            this.toolMenu.PerformLayout();
            this.layout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMenu;
        private System.Windows.Forms.ToolStripDropDownButton fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newItem;
        private System.Windows.Forms.ToolStripMenuItem loadItem;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripDropDownButton layerMenu;
        private System.Windows.Forms.ToolStripMenuItem overlayLayerOption;
        private System.Windows.Forms.ToolStripDropDownButton tilesetMenu;
        private System.Windows.Forms.ToolStripMenuItem tileset0;
        private System.Windows.Forms.ToolStripMenuItem tileset1;
        private System.Windows.Forms.ToolStripMenuItem tileset2;
        private System.Windows.Forms.ToolStripMenuItem tileset3;
        private System.Windows.Forms.ToolStripMenuItem tileset4;
        private System.Windows.Forms.ToolStripMenuItem tileset5;
        private System.Windows.Forms.ToolStripMenuItem tileset6;
        private System.Windows.Forms.ToolStripMenuItem tileset7;
        public System.Windows.Forms.Label lookingAt;
        private System.Windows.Forms.TableLayoutPanel layout;
        public TileMapEditorControl tileList;
        public System.Windows.Forms.Label selTileId;
        public TileSelectorControl tileSelector;
    }
}


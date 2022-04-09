using KSoft.MediaInfo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KSoft.MediaInfo
{    
    public partial class PluginConfiguration : Form
    {
        private Settings _settings;

        public PluginConfiguration(Settings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private void PluginConfiguration_Load(object sender, EventArgs e)
        {
            cbTitle.Checked = _settings.IsTitleEnabled;
            cbAlbumTitle.Checked = _settings.IsAlbumTitleEnabled;
            cbArtist.Checked = _settings.IsArtistEnabled;
            cbIsPlaying.Checked = _settings.IsIsPlayingEnabled;
            cbPlayingStatus.Checked = _settings.IsPlayingStatusEnabled;

            tbTitle.Text = _settings.TitleVariableName;
            tbAlbumTitle.Text = _settings.AlbumTitleVariableName;
            tbArtist.Text = _settings.ArtistVariableName;
            tbIsPlaying.Text = _settings.IsPlayingVariableName;
            tbPlayingStatus.Text = _settings.PlayingStatusVariableName;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            _settings.IsTitleEnabled = cbTitle.Checked;
            _settings.IsAlbumTitleEnabled = cbAlbumTitle.Checked;
            _settings.IsArtistEnabled = cbArtist.Checked;
            _settings.IsPlayingStatusEnabled = cbPlayingStatus.Checked;
            _settings.IsIsPlayingEnabled = cbIsPlaying.Checked;

            _settings.TitleVariableName = tbTitle.Text ;
            _settings.AlbumTitleVariableName = tbAlbumTitle.Text;
            _settings.ArtistVariableName = tbArtist.Text;
            _settings.IsPlayingVariableName = tbIsPlaying.Text;
            _settings.PlayingStatusVariableName = tbPlayingStatus.Text;
        }

        private void CheckCharacters(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-z0-9_\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
    }
}

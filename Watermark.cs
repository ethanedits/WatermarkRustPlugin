using Oxide.Game.Rust.Cui;
using Oxide.Core.Libraries.Covalence;
using Newtonsoft.Json;

namespace Oxide.Plugins
{
    [Info("Watermark", "EthanEDITS", 0.1)]
    [Description("A watermark plugin for rust")]

    public class Watermark : CovalencePlugin
    {
        #region UI_IP_JSON
        private static string TEMPLATE = @"
        [
          {
            ""name"": ""f96a-e995-af1d"",
            ""parent"": ""Hud"",
            ""components"": [
              {
                ""type"": ""UnityEngine.UI.Text"",
                ""color"": ""{colorText}"",
                ""fontSize"": ""{fontSize}"",
                ""align"": ""UpperLeft"",
                ""text"": ""{labeltext}""
              },
              {
                ""type"": ""RectTransform"",
                ""anchormin"": ""0.010 0"",
                ""anchormax"": ""0.5 0.990""
              }
            ]
          }
        ]
        ";
        #endregion

        public bool IP_isEnabled = true;

        void OnPlayerConnected()
        {
            foreach (var player in players.Connected)
            {
                var CustomLabel = configData.textStr;
                var CustomFontSize = configData.fontSize;
                var CustomColorRGBA = configData.colorRGBA;
                var Watermark_GUI = TEMPLATE.Replace("{labeltext}", CustomLabel).Replace("{fontSize}", CustomFontSize).Replace("{colorText}", CustomColorRGBA);
                if (IP_isEnabled)
                {
                    CuiHelper.AddUi(player.Object as BasePlayer, Watermark_GUI);
                }
            }
        }

        #region Config
        //CONFIG.JSON
        private ConfigData configData;
        class ConfigData
        {
            [JsonProperty(PropertyName = "Text String")]
            public string textStr = "Watermark text";
            [JsonProperty(PropertyName = "Font Size")]
            public string fontSize = "16";
            [JsonProperty(PropertyName = "Text Color RGBA")]
            public string colorRGBA = "1 0 0 1";
        }

        private bool LoadConfigVariables()
        {
            try
            {
                configData = Config.ReadObject<ConfigData>();
            }
            catch
            {
                return false;
            }
            SaveConfig(configData);
            return true;
        }

        void Init()
        {
            if (!LoadConfigVariables())
            {
                Puts("Watermark: Config File Issue Detected, Please delete file, or check syntax and fix");
                return;
            }
        }

        protected override void LoadDefaultConfig()
        {
            Puts("Creating Watermark Config");
            configData = new ConfigData();
            SaveConfig(configData);
        }

        void SaveConfig(ConfigData config)
        {
            Config.WriteObject(config, true);
        }
        #endregion
    }
}

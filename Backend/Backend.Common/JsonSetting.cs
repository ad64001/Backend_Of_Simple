using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class JsonSetting
    {
    }
    /// <summary>
    /// 数据库连接字符串配置选项
    /// </summary>
    public class SqlSugarOptions
    {
        /// <summary>
        /// 配置节名称常量
        /// </summary>
        public const string SectionName = "SqlSugarConfig";

        /// <summary>
        /// 默认数据库连接字符串
        /// 使用Required特性确保配置存在
        /// </summary>
        [Required(ErrorMessage = "必须配置Default连接字符串")]
        public string DefaultPath { get; set; } = string.Empty;
    }

    public class LoggingOptions
    {
        public const string SectionName = "Logging";

        [Required]
        public LogLevelOptions LogLevel { get; set; } = new();
    }

    public class LogLevelOptions
    {
        [Required]
        public string Default { get; set; } = string.Empty;

        [JsonPropertyName("Microsoft.AspNetCore")]
        [Required]
        public string MicrosoftAspNetCore { get; set; } = string.Empty;
    }
}

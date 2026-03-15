using System.ComponentModel;

namespace DiGi.GIS.PostgreSQL.UI.Enums
{
    [Description("Mode")]
    public enum Mode
    {
        [Description("Server")] Server,
        [Description("Client")] Client,
        [Description("Server And Cient")] ServerAndCient,
    }
}
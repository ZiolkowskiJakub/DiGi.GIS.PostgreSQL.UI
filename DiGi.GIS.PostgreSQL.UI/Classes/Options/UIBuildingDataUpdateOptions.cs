using DiGi.Core.Classes;
using DiGi.GIS.PostgreSQL.UI.Enums;
using System.Collections.Generic;

namespace DiGi.GIS.PostgreSQL.UI.Classes
{
    /// <summary>
    /// Represents the options for updating building data in a PostgreSQL database, specifying which types of building data updates should be performed.
    /// </summary>
    public class UIBuildingDataUpdateOptions : SerializableOptions
    {
        /// <summary>
        /// Gets or sets the collection of building data update types that specify which types of building data updates should be performed.
        /// </summary>
        public IEnumerable<BuildingDataUpdateType>? BuildingDataUpdateTypes { get; set; } = [ BuildingDataUpdateType.General, BuildingDataUpdateType.Database ];

        public UIBuildingDataUpdateOptions()
        {

        }
    }
}

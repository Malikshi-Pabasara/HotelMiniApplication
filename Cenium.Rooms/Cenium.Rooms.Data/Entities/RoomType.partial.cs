using Cenium.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenium.Rooms.Data
{
    [EntityInfo(ValueListProperties = "RoomTypeName,RoomTypeCode,PriceCode,MaxNoOfPersons", PrimaryDisplayProperty = "RoomTypeCode")]
    public partial class RoomType
    {

    }
}

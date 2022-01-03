/*
 * Copyright (c) Cenium AS. All Right Reserved
 *
 * This source is subject to the Cenium License.
 * Please see the License.txt file for more information.
 * All other rights reserved.
 * 
 * http://www.cenium.com
 * 
 * Change History:
 * 
 * User        Date          Comment
 * ----------- ------------- --------------------------------------------------------------------------------------------
 * Malikshi.P  11/23/2021    Created
 */

 #Version([1.0.0.0])

create table [dbo].[Rooms_Features] (
    [FeatureId] [bigint] not null identity,
    [FeatureName] [nvarchar](max) null,
	[FeatureCode] [nvarchar](max) not null,
    [Description] [nvarchar](max) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([FeatureId])
);
create table [dbo].[Rooms_RoomTypeFeatures] (
	[RoomTypeFeatureId] [bigint] not null identity,
	[FeatureId] [bigint] not null,
	[RoomTypeId] [bigint] not null,
	[TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomTypeFeatureId])
);
create table [dbo].[Rooms_Rooms] (
    [RoomId] [bigint] not null identity,
    [RoomNumber] [nvarchar](max) not null,
    [Status] [nvarchar](max) not null,
	[Name] [nvarchar](max) null,
	[Description] [nvarchar](max) null,
	[RoomWidth] [float] null,
	[RoomLength] [float] null,
	[SquareMeters] [float] null,
    [CeilingHeight] [float] null,
	[PriceCode] [nvarchar](max) null,
	[ColorCode] [nvarchar](max) null,
	[Property][nvarchar](max) not null,
	[PropertyContextId] [bigint] not null,
    [RoomTypeId] [bigint] not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomId])
);
create table [dbo].[Rooms_RoomTypes] (
    [RoomTypeId] [bigint] not null identity,
    [RoomTypeName] [nvarchar](max) null,
    [RoomTypeCode] [nvarchar](max) not null,
	[PriceCode] [nvarchar](max) null,
	[MaxNoOfPersons] [int] null,
	[Description] [nvarchar](max) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomTypeId])
);

alter table [dbo].[Rooms_Rooms] add constraint [Room_RoomType] foreign key ([RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;
alter table [dbo].[Rooms_RoomTypeFeatures] add constraint [Room_RoomType] foreign key ([RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;
alter table [dbo].[Rooms_RoomTypeFeatures] add constraint [Room_Feature] foreign key ([FeatureId]) references [dbo].[Rooms_Features]([FeatureId]) on delete cascade;


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [1.0.0.0], [8545E7F9867B90F80BA2AF3F4DE3BAC6F72B012375DEB36422C92AEBC2E804FD])

#Version([1.0.0.1])
#AddColumn([Rooms_Rooms], [ColorCode], [nvarchar(255) null ])

#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [1.0.0.1], [8545E7F9867B90F80BA2AF3F4DE3BAC6F72B012375DEB36422C92AEBC2E804FD])

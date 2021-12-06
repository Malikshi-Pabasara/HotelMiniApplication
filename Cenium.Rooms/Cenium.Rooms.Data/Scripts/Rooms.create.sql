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

/* Replace with component specific create script */



create table [dbo].[Rooms_Features] (
    [FeatureId] [bigint] not null identity,
    [FeatureName] [nvarchar](max) null,
	[FeatureCode] [nvarchar](max) not null,
    [Description] [nvarchar](max) null,
    [PriceCode] [nvarchar](max) null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([FeatureId])
);
create table [dbo].[FeatureRoomTypes] (
    [Feature_FeatureId] [bigint] not null,
    [RoomType_RoomTypeId] [bigint] not null,
    primary key ([Feature_FeatureId], [RoomType_RoomTypeId])
);
create table [dbo].[Rooms_Rooms] (
    [RoomId] [bigint] not null identity,
    [RoomNumber] [nvarchar](max) not null,
    [Status] [nvarchar](max) not null,
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
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([RoomTypeId])
);
alter table [dbo].[FeatureRoomTypes] add constraint [Feature_RoomTypes_Source] foreign key ([Feature_FeatureId]) references [dbo].[Rooms_Features]([FeatureId]) on delete cascade;
alter table [dbo].[FeatureRoomTypes] add constraint [Feature_RoomTypes_Target] foreign key ([RoomType_RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;
alter table [dbo].[Rooms_Rooms] add constraint [Room_RoomType] foreign key ([RoomTypeId]) references [dbo].[Rooms_RoomTypes]([RoomTypeId]) on delete cascade;


#SetVersion([Cenium.Rooms.Data.RoomsEntitiesDbContext], [Rooms], [1.0.0.0], [8AC1525CF9CD9D9F1BF2F222C4AFDAE8BB6B479B692F3F6AA2C2B1F9B524FD11])

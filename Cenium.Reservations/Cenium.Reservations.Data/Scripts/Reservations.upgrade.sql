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
 * Malikshi.P  10/28/2021    Created
 */

#Version([1.0.0.0])

create table [dbo].[Reservations_Reservations] (
	[ReservationId] [bigint] not null identity,
	[Number] [nvarchar](max) null,
	[PropertyContextId] [bigint] not null,
	[RoomId] [bigint] null,
	[ContactId] [bigint] not null,
	[ArrivalDate] [datetime] not null,
	[DepartureDate] [datetime] not null,
	[ReservationStatus] [nvarchar](max) null,
	[RoomNumber][nvarchar](max) null,
	[Price][nvarchar](max) null,
	[PaymentDone] [bit] null,
	[ContactName] [nvarchar](max) not null,
    [RoomTypeId] [bigint] not null,
    [RoomTypeCode] [nvarchar](max) null,
	[PropertyContextName] [nvarchar](max) null,
	[Balance] [nvarchar](max) null,
	[Discount] [nvarchar](max) null,
	[PaymentNumber] [nvarchar](max) null,
	[PaymentMethod] [nvarchar](max) null,
	[TotalAmount] [nvarchar](max) null,
	[TotalDays] [bigint](max) null,
	[NameOnCard] [nvarchar](max) null,
	[CreditCardNumber] [nvarchar](max) null,
	[CVV] [nvarchar](max) null,
	[ExpiryDate] [datetime] null,
	[PaymentStatus] [nvarchar](max) null,
	[TenantId] [uniqueidentifier] not null,
	[RowVersion] [rowversion] not null,
	primary key ([ReservationId])
);


#SetVersion([Cenium.Reservations.Data.ReservationsEntitiesDbContext], [Reservations], [1.0.0.0], [8545E7F9867B90F80BA2AF3F4DE3BAC6F72B012375DEB36422C92AEBC2E804FD])


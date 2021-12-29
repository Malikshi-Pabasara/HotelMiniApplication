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
 * Malikshi.P  11/01/2021    Created
 */

/* Replace with component specific create script */

create table [dbo].[Prices_Prices] (
	[PriceId] [bigint] not null identity,
	[PriceCode] [nvarchar](max) not null,
    [Description] [nvarchar](max) null,
	[Name] [nvarchar](max) null,
    [Amount] [float] not null,
	[TenantId] [uniqueidentifier] not null,
	[RowVersion] [rowversion] not null,
	primary key ([PriceId])
);

#SetVersion([Cenium.Prices.Data.PricesEntitiesDbContext], [Prices], [1.0.0.0], [8545E7F9867B90F80BA2AF3F4DE3BAC6F72B012375DEB36422C92AEBC2E804FD])


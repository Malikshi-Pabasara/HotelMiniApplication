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
 * Malikshi.P  10/27/2021    Created
 */

/* Replace with component specific create script */
create table [dbo].[Contacts_Contacts] (
	[ContactId] [bigint] not null identity,
	[Name] [nvarchar](max) not null,
	[Email] [nvarchar](max) null,
	[PhoneNumber] [nvarchar](max) null,
	[DoB] [datetime] null,
	[IDNumber] [nvarchar](max) null,
	[TenantId] [uniqueidentifier] not null,
	[RowVersion] [rowversion] not null,
	primary key ([ContactId])
);

#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [1.0.0.0], [8545E7F9867B90F80BA2AF3F4DE3BAC6F72B012375DEB36422C92AEBC2E804FD])


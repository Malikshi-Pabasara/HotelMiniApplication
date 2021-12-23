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
	[DateOfBirth] [datetime] null,
	[IdNumber] [nvarchar](max) null,
	[Address1] [nvarchar](max) null,
    [Address2] [nvarchar](max) null,
    [City] [nvarchar](max) null,
    [Gender] [nvarchar](max) null,
    [FirstName] [nvarchar](max) not null,
    [LastName] [nvarchar](max) not null,
    [PassportNo] [nvarchar](max) null,
	[MiddleName] [nvarchar](max) null,
	[PrimaryImageRef] [uniqueidentifier] null,
	[TenantId] [uniqueidentifier] not null,
	[RowVersion] [rowversion] not null,
	primary key ([ContactId])
);
create table [dbo].[Contacts_Emails] (
    [EmailId] [bigint] not null identity,
    [EmailAddress] [nvarchar](max) not null,
    [ContactId] [bigint] not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([EmailId])
);
create table [dbo].[Contacts_Phones] (
    [PhoneId] [bigint] not null identity,
    [PhoneNumber] [nvarchar](max) not null,
    [ContactId] [bigint] not null,
    [TenantId] [uniqueidentifier] not null,
    [RowVersion] [rowversion] not null,
    primary key ([PhoneId])
);

alter table [dbo].[Contacts_Emails] add constraint [Email_Contact] foreign key ([ContactId]) references [dbo].[Contacts_Contacts]([ContactId]) on delete cascade;
alter table [dbo].[Contacts_Phones] add constraint [Phone_Contact] foreign key ([ContactId]) references [dbo].[Contacts_Contacts]([ContactId]) on delete cascade;


#SetVersion([Cenium.Contacts.Data.ContactsEntitiesDbContext], [Contacts], [1.0.0.0], [8545E7F9867B90F80BA2AF3F4DE3BAC6F72B012375DEB36422C92AEBC2E804FD])


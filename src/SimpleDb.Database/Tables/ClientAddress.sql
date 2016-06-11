CREATE TABLE [dbo].[ClientAddress]
(
  ClientSymbol nvarchar(64) not null,
  Street nvarchar(64) not null,
  Number nvarchar(16) not null,
  ZipCode nvarchar(16) not null,
  City nvarchar(64) not null
)
go

alter table ClientAddress add constraint PK_ClientAddress_ClientSymbol primary key (ClientSymbol)
go


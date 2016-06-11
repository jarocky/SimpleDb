CREATE TABLE [dbo].[Client]
(
  Symbol nvarchar(64) not null,
  Name nvarchar(256) not null,
  Email nvarchar(256) not null,
  PhoneNumber nvarchar(16) not null,
  [Description] nvarchar(max) null
)
go

alter table Client add constraint PK_Client_Symbol primary key (Symbol)
go
alter table Client add constraint FK_ClientSymbol_ClientSymbol foreign key (Symbol) references ClientAddress (ClientSymbol)
go
/*
Post-Deployment Script Template              
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.    
 Use SQLCMD syntax to include a file in the post-deployment script.      
 Example:      :r .\myfile.sql                
 Use SQLCMD syntax to reference a variable in the post-deployment script.    
 Example:      :setvar TableName MyTable              
               SELECT * FROM [$(TableName)]          
--------------------------------------------------------------------------------------
*/

merge [dbo].[RequestPriority] as target
  using 
    ( 
      values     
      ( 1, N'Low' ),
      ( 2, N'Medium' ),
      ( 3, N'High' )
    )
    as source (Id, Name)
  on (target.[Id] = source.[Id])
  when matched and target.[Name] <> source.[Name] then 
      update set [Name] = source.[Name]
	when not matched then	
	    insert ([Id], [Name]) values (source.[Id], source.[Name]);

merge [dbo].[RequestStatus] as target
  using 
    ( 
      values     
      ( 1, N'New' ),
      ( 2, N'InProgress' ),
      ( 3, N'Resolved' )
    )
    as source (Id, Name)
  on (target.[Id] = source.[Id])
  when matched and target.[Name] <> source.[Name] then 
      update set [Name] = source.[Name]
	when not matched then	
	    insert ([Id], [Name]) values (source.[Id], source.[Name]);

  merge [dbo].[RequestType] as target
  using 
    ( 
      values     
      ( 1, N'Change' ),
      ( 2, N'Bug' ),
      ( 3, N'Critical' )
    )
    as source (Id, Name)
  on (target.[Id] = source.[Id])
  when matched and target.[Name] <> source.[Name] then 
      update set [Name] = source.[Name]
	when not matched then	
	    insert ([Id], [Name]) values (source.[Id], source.[Name]);
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
      ( 1, N'Niski' ),
      ( 2, N'Wysoki' ),
      ( 3, N'Krytyczny' )
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
      ( 1, N'Nowy' ),
      ( 2, N'Otwarty' ),
      ( 3, N'Zamkniety' )
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
      ( 1, N'Pytanie' ),
      ( 2, N'Problem' ),
      ( 3, N'Awaria' )
    )
    as source (Id, Name)
  on (target.[Id] = source.[Id])
  when matched and target.[Name] <> source.[Name] then 
      update set [Name] = source.[Name]
	when not matched then	
	    insert ([Id], [Name]) values (source.[Id], source.[Name]);
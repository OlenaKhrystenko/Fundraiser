/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [UserId]
      ,[UserName]
      ,[FullName]
      ,[Dob]
      ,[Address]
      ,[Password]
      ,[Email]
      ,[SequrityQuestion1]
      ,[SequrityQuestion2]
      ,[SequrityQuestion3]
  FROM [FinalDB].[dbo].[User_1s]
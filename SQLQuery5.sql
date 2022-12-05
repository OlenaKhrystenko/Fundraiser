/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [FundraiserId]
      ,[FundraiserName]
      ,[FundraiserDescription]
      ,[FundraiserGoal]
      ,[FundraiserCurrentAmount]
      ,[Owner]
  FROM [FinalDB].[dbo].[Fundraiser_1s]
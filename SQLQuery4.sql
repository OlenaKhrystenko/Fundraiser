/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [MigrationId]
      ,[ProductVersion]
  FROM [FinalDB].[dbo].[__EFMigrationsHistory]
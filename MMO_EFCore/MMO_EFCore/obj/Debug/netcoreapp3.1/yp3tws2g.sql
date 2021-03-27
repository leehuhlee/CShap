BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Item].[ItemGrade]', N'ItemGreade', N'COLUMN';
GO

DELETE FROM [__EFMigrationsHistory]
WHERE [MigrationId] = N'20210223115543_ITemGrade';
GO

COMMIT;
GO


BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Item].[ItemGrade]', N'ItemGreade', N'COLUMN';
GO

DELETE FROM [__EFMigrationsHistory]
WHERE [MigrationId] = N'20210223120813_ItemGrade';
GO

COMMIT;
GO


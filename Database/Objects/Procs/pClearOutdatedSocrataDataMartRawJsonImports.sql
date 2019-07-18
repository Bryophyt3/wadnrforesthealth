IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.pClearOutdatedSocrataDataMartRawJsonImports'))
    DROP PROCEDURE dbo.pClearOutdatedSocrataDataMartRawJsonImports
GO

CREATE PROCEDURE dbo.pClearOutdatedSocrataDataMartRawJsonImports
    (
        @daysOldToRemove int
    )
AS

begin

-- Figure out the current maximum API Load date. Note that this might be successful, or failed - we don't care
declare @maxFinanceApiLastLoadDate datetime
set @maxFinanceApiLastLoadDate = (select MAX(FinanceApiLastLoadDate) from dbo.SocrataDataMartRawJsonImport)

-- Calculate a cutoff date, before which we will delete records
declare @cutoffFinanceApiLastLoadDate datetime
set @cutoffFinanceApiLastLoadDate = DATEADD(DAY, -@daysOldToRemove, @maxFinanceApiLastLoadDate)

-- Delete records that were loaded before the cutoff date
delete from dbo.SocrataDataMartRawJsonImport
where FinanceApiLastLoadDate < @cutoffFinanceApiLastLoadDate

end
GO


/*

exec dbo.pClearOutdatedSocrataDataMartRawJsonImports 2

select * from [dbo].[SocrataDataMartRawJsonImport]

*/




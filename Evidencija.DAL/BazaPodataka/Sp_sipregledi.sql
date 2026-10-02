USE evidencijarvs;
GO


CREATE OR ALTER PROCEDURE dbo.sp_SviPregledi
    @DatumOd     DATETIME2     = NULL,
    @DatumDo     DATETIME2     = NULL,
    @HitanSlucaj BIT           = NULL,
    @Prioritet   NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        pregled_id,
        anamneza_id,
        telesna_temperatura,
        dijagnoza,
        terapija,
        hitanslucaj,
        prioritetpregleda,
        datumpregleda
    FROM dbo.pregled
    WHERE (@DatumOd IS NULL OR datumpregleda >= @DatumOd)
      AND (@DatumDo IS NULL OR datumpregleda < DATEADD(DAY, 1, CAST(@DatumDo AS DATE)))
      AND (@HitanSlucaj IS NULL OR hitanslucaj = @HitanSlucaj)
      AND (@Prioritet IS NULL OR @Prioritet = N'' OR prioritetpregleda = @Prioritet)
    ORDER BY datumpregleda DESC;
END
GO


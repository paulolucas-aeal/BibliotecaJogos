CREATE PROCEDURE [dbo].[sp_GetPwdRequestDataByGUID]
	@guid uniqueidentifier
AS
BEGIN
	SELECT * FROM tblNewPwdRequests WHERE guid = @guid
END



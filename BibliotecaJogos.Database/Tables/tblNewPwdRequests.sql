

CREATE TABLE [dbo].[tblNewPwdRequests](
	[id_pwdRecoveryRequest] INT NOT NULL PRIMARY KEY IDENTITY,
	[guid] UNIQUEIDENTIFIER NOT NULL,
	[email] VARCHAR(256) NOT NULL,
	[date_recovery_request] DATETIME NOT NULL,
	CONSTRAINT [UK_tblNewPwdRequests_guid] UNIQUE ([guid]),
	CONSTRAINT [UK_tblNewPwdRequests_email] UNIQUE ([email])
)







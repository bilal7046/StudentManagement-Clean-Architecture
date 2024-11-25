USE [StudentDb]
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudent]    Script Date: 11/25/2024 3:26:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudent]
    @StudentId UNIQUEIDENTIFIER
    
AS
BEGIN
    -- Declare a variable to hold the student data to be deleted
    DECLARE @OldData NVARCHAR(MAX);

    -- Get the student data before deleting
    SELECT @OldData = CONCAT('{"StudentId": "', @StudentId, '", "Name": "', Name, '", "Email": "', Email, '", "Address": "', Address, '"}')
    FROM Student
    WHERE Id = @StudentId;

    -- Insert an audit trail entry before deletion
	DECLARE @AuditId UNIQUEIDENTIFIER = NEWID();
    INSERT INTO AuditTrail (Id,TableName, RecordId, Action, OldData, NewData,Timestamp)
    VALUES (@AuditId,'Students', @StudentId, 'Delete', @OldData, NULL,GETDATE());

    -- Delete the student record from the Student table
    DELETE FROM Student
    WHERE Id = @StudentId;

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudents]    Script Date: 11/25/2024 3:26:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllStudents]
AS
BEGIN
    SELECT * FROM Student
    ORDER BY CreateAt DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[GetStudentDetail]    Script Date: 11/25/2024 3:26:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStudentDetail]
    @StudentId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT * FROM Student
    WHERE Id = @StudentId;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 11/25/2024 3:26:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertStudent]
    @StudentId UNIQUEIDENTIFIER,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(200)
  
AS
BEGIN
    -- Insert Student into the Students table
    INSERT INTO Student (Id, Name, Email, Address, CreateAt)
    VALUES (@StudentId, @Name, @Email, @Address, GETDATE());

    -- Insert an audit trail entry
	DECLARE @AuditId UNIQUEIDENTIFIER = NEWID();
     INSERT INTO AuditTrail (Id,TableName, RecordId, Action, OldData, NewData,Timestamp)
    VALUES (@AuditId,'Students', @StudentId, 'Insert', '', CONCAT('{"Name": "', @Name, '", "Email": "', @Email, '", "Address": "', @Address, '"}'),GETDATE());
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudent]    Script Date: 11/25/2024 3:26:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStudent]
    @StudentId	uNIQUEiDENTIFIER,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(200)
AS
BEGIN
    DECLARE @OldData NVARCHAR(MAX);

    -- Record old data
    SELECT @OldData = CONCAT('{"Name": "', Name, '", "Email": "', Email, '", "Address": "', Address, '"}')
    FROM Student
    WHERE Id = @StudentId;

    -- Update student record
    UPDATE Student
    SET Name = @Name, Email = @Email, Address = @Address, UpdatedAt = GETDATE()
    WHERE Id = @StudentId;

    -- Record in AuditTrail
	DECLARE @AuditId UNIQUEIDENTIFIER = NEWID();
    INSERT INTO AuditTrail (Id,TableName, RecordId, Action, OldData, NewData,Timestamp)
    VALUES (@AuditId,'Students', @StudentId, 'Update', @OldData, CONCAT('{"Name": "', @Name, '", "Email": "', @Email, '", "Address": "', @Address, '"}'),GETDATE());
END
GO

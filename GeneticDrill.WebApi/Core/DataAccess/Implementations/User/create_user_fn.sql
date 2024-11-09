CREATE TYPE create_user_response AS (
    "id" UUID,
    first_name VARCHAR,
    middle_name VARCHAR,
    last_name VARCHAR,
    email VARCHAR,
    google_picture_url VARCHAR,
    frontend_theme VARCHAR,
    is_blocked BOOLEAN,
    is_deleted BOOLEAN,
    created_at TIMESTAMP
    );

CREATE OR REPLACE FUNCTION create_user(email VARCHAR) 
RETURNS create_user_response AS $$
DECLARE
response create_user_response;
BEGIN
SELECT u.id
     , u.first_name
     , u.middle_name
     , u.last_name
     , u.google_picture_url
     , u.frontend_theme
     , u.is_blocked
     , u.is_deleted
     , u.created_at
INTO response
FROM users AS u
WHERE u.email = email;

RETURN response;
END;
$$ LANGUAGE plpgsql;
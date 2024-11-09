CREATE OR REPLACE FUNCTION get_user_by_email(email VARCHAR) RETURNS TABLE(
    id UUID, 
    first_name VARCHAR, 
    middle_name VARCHAR, 
    last_name VARCHAR, 
    google_picture_url VARCHAR, 
    frontend_theme VARCHAR, 
    is_blocked BOOLEAN, 
    is_deleted BOOLEAN, 
    created_at TIMESTAMP) AS $$
BEGIN
RETURN QUERY
SELECT u.id
     , u.first_name
     , u.middle_name
     , u.last_name
     , u.google_picture_url
     , u.frontend_theme
     , u.is_blocked
     , u.is_deleted
     , u.created_at
FROM users u
WHERE u.email = get_user_by_email.email;
END;
$$ LANGUAGE plpgsql;
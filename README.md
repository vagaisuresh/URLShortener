## URL Shortener

```
MySQL
CREATE TABLE ShortUrls (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    LongUrl TEXT NOT NULL,
    ShortId VARCHAR(10) NOT NULL,
    Domain VARCHAR(255) NOT NULL,
    ShortUrlValue VARCHAR(255) NOT NULL,
    Description TEXT,
    ExpireAtDateTime DATETIME,
    ExpireAtViews INT,
    PublicStats BOOLEAN,
    HasPassword BOOLEAN,
    CreatedAt DATETIME,
    UpdatedAt DATETIME
);

MS SQL Server
CREATE TABLE ShortUrls (
    Id INT PRIMARY KEY IDENTITY(1,1),
    LongUrl TEXT NOT NULL,
    ShortId VARCHAR(10) NOT NULL,
    Domain VARCHAR(255) NOT NULL,
    ShortUrlValue VARCHAR(255) NOT NULL,
    Description NVARCHAR(255),
    ExpireAtDateTime DATETIME,
    ExpireAtViews INT,
    PublicStats BIT,
    HasPassword BIT NOT NULL,
    CreatedAtDateTime DATETIME,
    UpdatedAtDateTime DATETIME
);
```

---

### 🔗 Basic Information

---

→ LongUrl: This is the original, full-length URL that the short link points to.


- ✅ Send bulk emails via SMTP
- ✅ MIME and HTML email formatting
- ✅ Blazor front-end for seamless user experience
- ✅ Clean Architecture with layered structure
- ✅ SQL Server for data persistence
- ✅ Repository & Unit of Work patterns
- ✅ Easily extensible and testable codebase

---

🔗 Basic Information
long_url:
https://code-maze.com/net-core-web-development-part4/
→ This is the original, full-length URL that the short link points to.

short_url:
https://t.ly/B1j7u
→ This is the shortened version of the original link, which redirects to the long_url.

short_id:
B1j7u
→ The unique ID used to generate the short URL. It's appended to the domain (t.ly) to form the full short link.

domain:
https://t.ly/
→ The domain used by the URL shortener.

🗓️ Timestamps
created_at and updated_at:
2025-07-01T12:06:51.000000Z
→ These indicate when the short URL was created and last updated, respectively.

🔒 Security and Access
has_password:
false
→ The short URL does not require a password to access.

public_stats:
false
→ Usage statistics (like clicks or traffic) are not publicly accessible.

⏳ Expiration (Optional, Unused Here)
expire_at_datetime:
null
→ The link does not have a time-based expiration.

expire_at_views:
null
→ The link does not expire after a certain number of views.

🧠 Meta
meta.smart_urls:
[]
→ No additional smart URLs (like device-specific redirects) are configured.

meta.expiration_url:
null
→ No alternative link is defined for when the short URL expires.

Summary
You have a short link https://t.ly/B1j7u that redirects to a Code Maze article on ".NET Core Web Development – Part 4". It’s active, doesn't expire, doesn't require a password, and doesn't expose public stats.

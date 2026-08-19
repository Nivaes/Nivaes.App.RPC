using System;
using System.Collections.Generic;
using System.Text;

namespace Nivaes.EntityFrameworkCore.Sqlite;

public sealed record VersionScriptMigration(
    string Id,
    string ResourceName);

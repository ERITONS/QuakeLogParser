using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuakeLogParser.Api.Models.Enum
{
    public enum EGameAction
    {
        InitGame,
        ShutdownGame,
        Exit,
        ClientConnect,
        ClientDisconnect,
        ClientBegin,
        ClientUserinfoChanged,
        Item,
        Kill,
        score
    }
}
﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Lightup
{
    using Microsoft.CodeAnalysis.CSharp;

    internal static class LanguageVersionEx
    {
        public const LanguageVersion Default = 0;
        public const LanguageVersion CSharp7 = (LanguageVersion)7;
#pragma warning disable SA1310 // Field names should not contain underscore
        public const LanguageVersion CSharp7_1 = (LanguageVersion)701;
        public const LanguageVersion CSharp7_2 = (LanguageVersion)702;
        public const LanguageVersion CSharp7_3 = (LanguageVersion)703;
#pragma warning restore SA1310 // Field names should not contain underscore
        public const LanguageVersion Latest = (LanguageVersion)int.MaxValue;
    }
}

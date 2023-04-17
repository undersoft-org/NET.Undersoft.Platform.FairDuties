using System;
using System.Runtime.InteropServices;

namespace UltimatR
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class Dto : Identifiable, IDto
    {
    }
}
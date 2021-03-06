/*
 * Copyright (C) 2011 mooege project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System.Text;

namespace Mooege.Net.GS.Message.Definitions.ACD
{
    [Message(Opcodes.ACDGroupMessage)]
    public class ACDGroupMessage : GameMessage
    {
        public uint ActorID; // Actor's DynamicID
        public int Group1Hash;
        public int Group2Hash;

        public ACDGroupMessage() : base(Opcodes.ACDGroupMessage) { }

        public override void Parse(GameBitBuffer buffer)
        {
            ActorID = buffer.ReadUInt(32);
            Group1Hash = buffer.ReadInt(32);
            Group2Hash = buffer.ReadInt(32);
        }

        public override void Encode(GameBitBuffer buffer)
        {
            buffer.WriteUInt(32, ActorID);
            buffer.WriteInt(32, Group1Hash);
            buffer.WriteInt(32, Group2Hash);
        }

        public override void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("ACDGroupMessage:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad); b.AppendLine("ActorID: 0x" + ActorID.ToString("X8") + " (" + ActorID + ")");
            b.Append(' ', pad); b.AppendLine("Field1: 0x" + Group1Hash.ToString("X8") + " (" + Group1Hash + ")");
            b.Append(' ', pad); b.AppendLine("Field2: 0x" + Group2Hash.ToString("X8") + " (" + Group2Hash + ")");
            b.Append(' ', --pad);
            b.AppendLine("}");
        }


    }
}

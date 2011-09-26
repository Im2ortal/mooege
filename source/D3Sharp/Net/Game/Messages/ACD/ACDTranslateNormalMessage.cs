﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D3Sharp.Net.Game.Messages.ACD
{
    [IncomingMessage(new[] {Opcodes.ACDTranslateNormalMessage1, Opcodes.ACDTranslateNormalMessage2})]
    public class ACDTranslateNormalMessage: GameMessage
    {
        public int Field0;
        public Vector3D Field1;
        public float /* angle */? Field2;
        public bool? Field3;
        public float? Field4;
        public int? Field5;
        public int? Field6;
        public int? Field7;

        public override void Handle(GameClient client)
        {
            if (this.Field1 != null)
                client.position = this.Field1;
        }

        public override void Parse(GameBitBuffer buffer)
        {
            Field0 = buffer.ReadInt(32);
            if (buffer.ReadBool())
            {
                Field1 = new Vector3D();
                Field1.Parse(buffer);
            }
            if (buffer.ReadBool())
            {
                Field2 = buffer.ReadFloat32();
            }
            if (buffer.ReadBool())
            {
                Field3 = buffer.ReadBool();
            }
            if (buffer.ReadBool())
            {
                Field4 = buffer.ReadFloat32();
            }
            if (buffer.ReadBool())
            {
                Field5 = buffer.ReadInt(24);
            }
            if (buffer.ReadBool())
            {
                Field6 = buffer.ReadInt(21) + (-1);
            }
            if (buffer.ReadBool())
            {
                Field7 = buffer.ReadInt(32);
            }
        }

        public override void Encode(GameBitBuffer buffer)
        {
            buffer.WriteInt(32, Field0);
            buffer.WriteBool(Field1 != null);
            if (Field1 != null)
            {
                Field1.Encode(buffer);
            }
            buffer.WriteBool(Field2.HasValue);
            if (Field2.HasValue)
            {
                buffer.WriteFloat32(Field2.Value);
            }
            buffer.WriteBool(Field3.HasValue);
            if (Field3.HasValue)
            {
                buffer.WriteBool(Field3.Value);
            }
            buffer.WriteBool(Field4.HasValue);
            if (Field4.HasValue)
            {
                buffer.WriteFloat32(Field4.Value);
            }
            buffer.WriteBool(Field5.HasValue);
            if (Field5.HasValue)
            {
                buffer.WriteInt(24, Field5.Value);
            }
            buffer.WriteBool(Field6.HasValue);
            if (Field6.HasValue)
            {
                buffer.WriteInt(21, Field6.Value - (-1));
            }
            buffer.WriteBool(Field7.HasValue);
            if (Field7.HasValue)
            {
                buffer.WriteInt(32, Field7.Value);
            }
        }

        public override void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("ACDTranslateNormalMessage:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad); b.AppendLine("Field0: 0x" + Field0.ToString("X8"));
            if (Field1 != null)
            {
                Field1.AsText(b, pad);
            }
            if (Field2.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field2.Value: " + Field2.Value.ToString("G"));
            }
            if (Field3.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field3.Value: " + (Field3.Value ? "true" : "false"));
            }
            if (Field4.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field4.Value: " + Field4.Value.ToString("G"));
            }
            if (Field5.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field5.Value: 0x" + Field5.Value.ToString("X8") + " (" + Field5.Value + ")");
            }
            if (Field6.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field6.Value: 0x" + Field6.Value.ToString("X8") + " (" + Field6.Value + ")");
            }
            if (Field7.HasValue)
            {
                b.Append(' ', pad); b.AppendLine("Field7.Value: 0x" + Field7.Value.ToString("X8") + " (" + Field7.Value + ")");
            }
            b.Append(' ', --pad);
            b.AppendLine("}");
        }
    }
}
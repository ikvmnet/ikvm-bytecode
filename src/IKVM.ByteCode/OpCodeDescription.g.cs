namespace IKVM.ByteCode
{

    /// <summary>
    /// Java opcode values as defined by the JVM specification.
    /// </summary>
    readonly partial struct OpCodeDescription
    {

        /// <summary>
        /// The 'nop' opcode.
        /// </summary>
        //public static OpCodeDescription Nop => new OpCodeDescription(OpCode.Nop);

        /// <summary>
        /// The 'aconst_null' opcode.
        /// </summary>
        //public static OpCodeDescription AconstNull => new OpCodeDescription(OpCode.AconstNull);

        /// <summary>
        /// The 'iconst_m1' opcode.
        /// </summary>
        //public static OpCodeDescription IconstM1 => new OpCodeDescription(OpCode.IconstM1);

        /// <summary>
        /// The 'iconst_0' opcode.
        /// </summary>
        //public static OpCodeDescription Iconst0 => new OpCodeDescription(OpCode.Iconst0);

        /// <summary>
        /// The 'iconst_1' opcode.
        /// </summary>
        //public static OpCodeDescription Iconst1 => new OpCodeDescription(OpCode.Iconst1);

        /// <summary>
        /// The 'iconst_2' opcode.
        /// </summary>
        //public static OpCodeDescription Iconst2 => new OpCodeDescription(OpCode.Iconst2);

        /// <summary>
        /// The 'iconst_3' opcode.
        /// </summary>
        //public static OpCodeDescription Iconst3 => new OpCodeDescription(OpCode.Iconst3);

        /// <summary>
        /// The 'iconst_4' opcode.
        /// </summary>
        //public static OpCodeDescription Iconst4 => new OpCodeDescription(OpCode.Iconst4);

        /// <summary>
        /// The 'iconst_5' opcode.
        /// </summary>
        //public static OpCodeDescription Iconst5 => new OpCodeDescription(OpCode.Iconst5);

        /// <summary>
        /// The 'lconst_0' opcode.
        /// </summary>
        //public static OpCodeDescription Lconst0 => new OpCodeDescription(OpCode.Lconst0);

        /// <summary>
        /// The 'lconst_1' opcode.
        /// </summary>
        //public static OpCodeDescription Lconst1 => new OpCodeDescription(OpCode.Lconst1);

        /// <summary>
        /// The 'fconst_0' opcode.
        /// </summary>
        //public static OpCodeDescription Fconst0 => new OpCodeDescription(OpCode.Fconst0);

        /// <summary>
        /// The 'fconst_1' opcode.
        /// </summary>
        //public static OpCodeDescription Fconst1 => new OpCodeDescription(OpCode.Fconst1);

        /// <summary>
        /// The 'fconst_2' opcode.
        /// </summary>
        //public static OpCodeDescription Fconst2 => new OpCodeDescription(OpCode.Fconst2);

        /// <summary>
        /// The 'dconst_0' opcode.
        /// </summary>
        //public static OpCodeDescription Dconst0 => new OpCodeDescription(OpCode.Dconst0);

        /// <summary>
        /// The 'dconst_1' opcode.
        /// </summary>
        //public static OpCodeDescription Dconst1 => new OpCodeDescription(OpCode.Dconst1);

        /// <summary>
        /// The 'bipush' opcode.
        /// </summary>
        //public static OpCodeDescription Bipush => new OpCodeDescription(OpCode.Bipush);

        /// <summary>
        /// The 'sipush' opcode.
        /// </summary>
        //public static OpCodeDescription Sipush => new OpCodeDescription(OpCode.Sipush);

        /// <summary>
        /// The 'ldc' opcode.
        /// </summary>
        //public static OpCodeDescription Ldc => new OpCodeDescription(OpCode.Ldc);

        /// <summary>
        /// The 'ldc_w' opcode.
        /// </summary>
        //public static OpCodeDescription LdcW => new OpCodeDescription(OpCode.LdcW);

        /// <summary>
        /// The 'ldc2_w' opcode.
        /// </summary>
        //public static OpCodeDescription Ldc2W => new OpCodeDescription(OpCode.Ldc2W);

        /// <summary>
        /// The 'iload' opcode.
        /// </summary>
        //public static OpCodeDescription Iload => new OpCodeDescription(OpCode.Iload);

        /// <summary>
        /// The 'lload' opcode.
        /// </summary>
        //public static OpCodeDescription Lload => new OpCodeDescription(OpCode.Lload);

        /// <summary>
        /// The 'fload' opcode.
        /// </summary>
        //public static OpCodeDescription Fload => new OpCodeDescription(OpCode.Fload);

        /// <summary>
        /// The 'dload' opcode.
        /// </summary>
        //public static OpCodeDescription Dload => new OpCodeDescription(OpCode.Dload);

        /// <summary>
        /// The 'aload' opcode.
        /// </summary>
        //public static OpCodeDescription Aload => new OpCodeDescription(OpCode.Aload);

        /// <summary>
        /// The 'iload_0' opcode.
        /// </summary>
        //public static OpCodeDescription Iload0 => new OpCodeDescription(OpCode.Iload0);

        /// <summary>
        /// The 'iload_1' opcode.
        /// </summary>
        //public static OpCodeDescription Iload1 => new OpCodeDescription(OpCode.Iload1);

        /// <summary>
        /// The 'iload_2' opcode.
        /// </summary>
        //public static OpCodeDescription Iload2 => new OpCodeDescription(OpCode.Iload2);

        /// <summary>
        /// The 'iload_3' opcode.
        /// </summary>
        //public static OpCodeDescription Iload3 => new OpCodeDescription(OpCode.Iload3);

        /// <summary>
        /// The 'lload_0' opcode.
        /// </summary>
        //public static OpCodeDescription Lload0 => new OpCodeDescription(OpCode.Lload0);

        /// <summary>
        /// The 'lload_1' opcode.
        /// </summary>
        //public static OpCodeDescription Lload1 => new OpCodeDescription(OpCode.Lload1);

        /// <summary>
        /// The 'lload_2' opcode.
        /// </summary>
        //public static OpCodeDescription Lload2 => new OpCodeDescription(OpCode.Lload2);

        /// <summary>
        /// The 'lload_3' opcode.
        /// </summary>
        //public static OpCodeDescription Lload3 => new OpCodeDescription(OpCode.Lload3);

        /// <summary>
        /// The 'fload_0' opcode.
        /// </summary>
        //public static OpCodeDescription Fload0 => new OpCodeDescription(OpCode.Fload0);

        /// <summary>
        /// The 'fload_1' opcode.
        /// </summary>
        //public static OpCodeDescription Fload1 => new OpCodeDescription(OpCode.Fload1);

        /// <summary>
        /// The 'fload_2' opcode.
        /// </summary>
        //public static OpCodeDescription Fload2 => new OpCodeDescription(OpCode.Fload2);

        /// <summary>
        /// The 'fload_3' opcode.
        /// </summary>
        //public static OpCodeDescription Fload3 => new OpCodeDescription(OpCode.Fload3);

        /// <summary>
        /// The 'dload_0' opcode.
        /// </summary>
        //public static OpCodeDescription Dload0 => new OpCodeDescription(OpCode.Dload0);

        /// <summary>
        /// The 'dload_1' opcode.
        /// </summary>
        //public static OpCodeDescription Dload1 => new OpCodeDescription(OpCode.Dload1);

        /// <summary>
        /// The 'dload_2' opcode.
        /// </summary>
        //public static OpCodeDescription Dload2 => new OpCodeDescription(OpCode.Dload2);

        /// <summary>
        /// The 'dload_3' opcode.
        /// </summary>
        //public static OpCodeDescription Dload3 => new OpCodeDescription(OpCode.Dload3);

        /// <summary>
        /// The 'aload_0' opcode.
        /// </summary>
        //public static OpCodeDescription Aload0 => new OpCodeDescription(OpCode.Aload0);

        /// <summary>
        /// The 'aload_1' opcode.
        /// </summary>
        //public static OpCodeDescription Aload1 => new OpCodeDescription(OpCode.Aload1);

        /// <summary>
        /// The 'aload_2' opcode.
        /// </summary>
        //public static OpCodeDescription Aload2 => new OpCodeDescription(OpCode.Aload2);

        /// <summary>
        /// The 'aload_3' opcode.
        /// </summary>
        //public static OpCodeDescription Aload3 => new OpCodeDescription(OpCode.Aload3);

        /// <summary>
        /// The 'iaload' opcode.
        /// </summary>
        //public static OpCodeDescription Iaload => new OpCodeDescription(OpCode.Iaload);

        /// <summary>
        /// The 'laload' opcode.
        /// </summary>
        //public static OpCodeDescription Laload => new OpCodeDescription(OpCode.Laload);

        /// <summary>
        /// The 'faload' opcode.
        /// </summary>
        //public static OpCodeDescription Faload => new OpCodeDescription(OpCode.Faload);

        /// <summary>
        /// The 'daload' opcode.
        /// </summary>
        //public static OpCodeDescription Daload => new OpCodeDescription(OpCode.Daload);

        /// <summary>
        /// The 'aaload' opcode.
        /// </summary>
        //public static OpCodeDescription Aaload => new OpCodeDescription(OpCode.Aaload);

        /// <summary>
        /// The 'baload' opcode.
        /// </summary>
        //public static OpCodeDescription Baload => new OpCodeDescription(OpCode.Baload);

        /// <summary>
        /// The 'caload' opcode.
        /// </summary>
        //public static OpCodeDescription Caload => new OpCodeDescription(OpCode.Caload);

        /// <summary>
        /// The 'saload' opcode.
        /// </summary>
        //public static OpCodeDescription Saload => new OpCodeDescription(OpCode.Saload);

        /// <summary>
        /// The 'istore' opcode.
        /// </summary>
        //public static OpCodeDescription Istore => new OpCodeDescription(OpCode.Istore);

        /// <summary>
        /// The 'lstore' opcode.
        /// </summary>
        //public static OpCodeDescription Lstore => new OpCodeDescription(OpCode.Lstore);

        /// <summary>
        /// The 'fstore' opcode.
        /// </summary>
        //public static OpCodeDescription Fstore => new OpCodeDescription(OpCode.Fstore);

        /// <summary>
        /// The 'dstore' opcode.
        /// </summary>
        //public static OpCodeDescription Dstore => new OpCodeDescription(OpCode.Dstore);

        /// <summary>
        /// The 'astore' opcode.
        /// </summary>
        //public static OpCodeDescription Astore => new OpCodeDescription(OpCode.Astore);

        /// <summary>
        /// The 'istore_0' opcode.
        /// </summary>
        //public static OpCodeDescription Istore0 => new OpCodeDescription(OpCode.Istore0);

        /// <summary>
        /// The 'istore_1' opcode.
        /// </summary>
        //public static OpCodeDescription Istore1 => new OpCodeDescription(OpCode.Istore1);

        /// <summary>
        /// The 'istore_2' opcode.
        /// </summary>
        //public static OpCodeDescription Istore2 => new OpCodeDescription(OpCode.Istore2);

        /// <summary>
        /// The 'istore_3' opcode.
        /// </summary>
        //public static OpCodeDescription Istore3 => new OpCodeDescription(OpCode.Istore3);

        /// <summary>
        /// The 'lstore_0' opcode.
        /// </summary>
        //public static OpCodeDescription Lstore0 => new OpCodeDescription(OpCode.Lstore0);

        /// <summary>
        /// The 'lstore_1' opcode.
        /// </summary>
        //public static OpCodeDescription Lstore1 => new OpCodeDescription(OpCode.Lstore1);

        /// <summary>
        /// The 'lstore_2' opcode.
        /// </summary>
        //public static OpCodeDescription Lstore2 => new OpCodeDescription(OpCode.Lstore2);

        /// <summary>
        /// The 'lstore_3' opcode.
        /// </summary>
        //public static OpCodeDescription Lstore3 => new OpCodeDescription(OpCode.Lstore3);

        /// <summary>
        /// The 'fstore_0' opcode.
        /// </summary>
        //public static OpCodeDescription Fstore0 => new OpCodeDescription(OpCode.Fstore0);

        /// <summary>
        /// The 'fstore_1' opcode.
        /// </summary>
        //public static OpCodeDescription Fstore1 => new OpCodeDescription(OpCode.Fstore1);

        /// <summary>
        /// The 'fstore_2' opcode.
        /// </summary>
        //public static OpCodeDescription Fstore2 => new OpCodeDescription(OpCode.Fstore2);

        /// <summary>
        /// The 'fstore_3' opcode.
        /// </summary>
        //public static OpCodeDescription Fstore3 => new OpCodeDescription(OpCode.Fstore3);

        /// <summary>
        /// The 'dstore_0' opcode.
        /// </summary>
        //public static OpCodeDescription Dstore0 => new OpCodeDescription(OpCode.Dstore0);

        /// <summary>
        /// The 'dstore_1' opcode.
        /// </summary>
        //public static OpCodeDescription Dstore1 => new OpCodeDescription(OpCode.Dstore1);

        /// <summary>
        /// The 'dstore_2' opcode.
        /// </summary>
        //public static OpCodeDescription Dstore2 => new OpCodeDescription(OpCode.Dstore2);

        /// <summary>
        /// The 'dstore_3' opcode.
        /// </summary>
        //public static OpCodeDescription Dstore3 => new OpCodeDescription(OpCode.Dstore3);

        /// <summary>
        /// The 'astore_0' opcode.
        /// </summary>
        //public static OpCodeDescription Astore0 => new OpCodeDescription(OpCode.Astore0);

        /// <summary>
        /// The 'astore_1' opcode.
        /// </summary>
        //public static OpCodeDescription Astore1 => new OpCodeDescription(OpCode.Astore1);

        /// <summary>
        /// The 'astore_2' opcode.
        /// </summary>
        //public static OpCodeDescription Astore2 => new OpCodeDescription(OpCode.Astore2);

        /// <summary>
        /// The 'astore_3' opcode.
        /// </summary>
        //public static OpCodeDescription Astore3 => new OpCodeDescription(OpCode.Astore3);

        /// <summary>
        /// The 'iastore' opcode.
        /// </summary>
        //public static OpCodeDescription Iastore => new OpCodeDescription(OpCode.Iastore);

        /// <summary>
        /// The 'lastore' opcode.
        /// </summary>
        //public static OpCodeDescription Lastore => new OpCodeDescription(OpCode.Lastore);

        /// <summary>
        /// The 'fastore' opcode.
        /// </summary>
        //public static OpCodeDescription Fastore => new OpCodeDescription(OpCode.Fastore);

        /// <summary>
        /// The 'dastore' opcode.
        /// </summary>
        //public static OpCodeDescription Dastore => new OpCodeDescription(OpCode.Dastore);

        /// <summary>
        /// The 'aastore' opcode.
        /// </summary>
        //public static OpCodeDescription Aastore => new OpCodeDescription(OpCode.Aastore);

        /// <summary>
        /// The 'bastore' opcode.
        /// </summary>
        //public static OpCodeDescription Bastore => new OpCodeDescription(OpCode.Bastore);

        /// <summary>
        /// The 'castore' opcode.
        /// </summary>
        //public static OpCodeDescription Castore => new OpCodeDescription(OpCode.Castore);

        /// <summary>
        /// The 'sastore' opcode.
        /// </summary>
        //public static OpCodeDescription Sastore => new OpCodeDescription(OpCode.Sastore);

        /// <summary>
        /// The 'pop' opcode.
        /// </summary>
        //public static OpCodeDescription Pop => new OpCodeDescription(OpCode.Pop);

        /// <summary>
        /// The 'pop2' opcode.
        /// </summary>
        //public static OpCodeDescription Pop2 => new OpCodeDescription(OpCode.Pop2);

        /// <summary>
        /// The 'dup' opcode.
        /// </summary>
        //public static OpCodeDescription Dup => new OpCodeDescription(OpCode.Dup);

        /// <summary>
        /// The 'dup_x1' opcode.
        /// </summary>
        //public static OpCodeDescription DupX1 => new OpCodeDescription(OpCode.DupX1);

        /// <summary>
        /// The 'dup_x2' opcode.
        /// </summary>
        //public static OpCodeDescription DupX2 => new OpCodeDescription(OpCode.DupX2);

        /// <summary>
        /// The 'dup2' opcode.
        /// </summary>
        //public static OpCodeDescription Dup2 => new OpCodeDescription(OpCode.Dup2);

        /// <summary>
        /// The 'dup2_x1' opcode.
        /// </summary>
        //public static OpCodeDescription Dup2X1 => new OpCodeDescription(OpCode.Dup2X1);

        /// <summary>
        /// The 'dup2_x2' opcode.
        /// </summary>
        //public static OpCodeDescription Dup2X2 => new OpCodeDescription(OpCode.Dup2X2);

        /// <summary>
        /// The 'swap' opcode.
        /// </summary>
        //public static OpCodeDescription Swap => new OpCodeDescription(OpCode.Swap);

        /// <summary>
        /// The 'iadd' opcode.
        /// </summary>
        //public static OpCodeDescription Iadd => new OpCodeDescription(OpCode.Iadd);

        /// <summary>
        /// The 'ladd' opcode.
        /// </summary>
        //public static OpCodeDescription Ladd => new OpCodeDescription(OpCode.Ladd);

        /// <summary>
        /// The 'fadd' opcode.
        /// </summary>
        //public static OpCodeDescription Fadd => new OpCodeDescription(OpCode.Fadd);

        /// <summary>
        /// The 'dadd' opcode.
        /// </summary>
        //public static OpCodeDescription Dadd => new OpCodeDescription(OpCode.Dadd);

        /// <summary>
        /// The 'isub' opcode.
        /// </summary>
        //public static OpCodeDescription Isub => new OpCodeDescription(OpCode.Isub);

        /// <summary>
        /// The 'lsub' opcode.
        /// </summary>
        //public static OpCodeDescription Lsub => new OpCodeDescription(OpCode.Lsub);

        /// <summary>
        /// The 'fsub' opcode.
        /// </summary>
        //public static OpCodeDescription Fsub => new OpCodeDescription(OpCode.Fsub);

        /// <summary>
        /// The 'dsub' opcode.
        /// </summary>
        //public static OpCodeDescription Dsub => new OpCodeDescription(OpCode.Dsub);

        /// <summary>
        /// The 'imul' opcode.
        /// </summary>
        //public static OpCodeDescription Imul => new OpCodeDescription(OpCode.Imul);

        /// <summary>
        /// The 'lmul' opcode.
        /// </summary>
        //public static OpCodeDescription Lmul => new OpCodeDescription(OpCode.Lmul);

        /// <summary>
        /// The 'fmul' opcode.
        /// </summary>
        //public static OpCodeDescription Fmul => new OpCodeDescription(OpCode.Fmul);

        /// <summary>
        /// The 'dmul' opcode.
        /// </summary>
        //public static OpCodeDescription Dmul => new OpCodeDescription(OpCode.Dmul);

        /// <summary>
        /// The 'idiv' opcode.
        /// </summary>
        //public static OpCodeDescription Idiv => new OpCodeDescription(OpCode.Idiv);

        /// <summary>
        /// The 'ldiv' opcode.
        /// </summary>
        //public static OpCodeDescription Ldiv => new OpCodeDescription(OpCode.Ldiv);

        /// <summary>
        /// The 'fdiv' opcode.
        /// </summary>
        //public static OpCodeDescription Fdiv => new OpCodeDescription(OpCode.Fdiv);

        /// <summary>
        /// The 'ddiv' opcode.
        /// </summary>
        //public static OpCodeDescription Ddiv => new OpCodeDescription(OpCode.Ddiv);

        /// <summary>
        /// The 'irem' opcode.
        /// </summary>
        //public static OpCodeDescription Irem => new OpCodeDescription(OpCode.Irem);

        /// <summary>
        /// The 'lrem' opcode.
        /// </summary>
        //public static OpCodeDescription Lrem => new OpCodeDescription(OpCode.Lrem);

        /// <summary>
        /// The 'frem' opcode.
        /// </summary>
        //public static OpCodeDescription Frem => new OpCodeDescription(OpCode.Frem);

        /// <summary>
        /// The 'drem' opcode.
        /// </summary>
        //public static OpCodeDescription Drem => new OpCodeDescription(OpCode.Drem);

        /// <summary>
        /// The 'ineg' opcode.
        /// </summary>
        //public static OpCodeDescription Ineg => new OpCodeDescription(OpCode.Ineg);

        /// <summary>
        /// The 'lneg' opcode.
        /// </summary>
        //public static OpCodeDescription Lneg => new OpCodeDescription(OpCode.Lneg);

        /// <summary>
        /// The 'fneg' opcode.
        /// </summary>
        //public static OpCodeDescription Fneg => new OpCodeDescription(OpCode.Fneg);

        /// <summary>
        /// The 'dneg' opcode.
        /// </summary>
        //public static OpCodeDescription Dneg => new OpCodeDescription(OpCode.Dneg);

        /// <summary>
        /// The 'ishl' opcode.
        /// </summary>
        //public static OpCodeDescription Ishl => new OpCodeDescription(OpCode.Ishl);

        /// <summary>
        /// The 'lshl' opcode.
        /// </summary>
        //public static OpCodeDescription Lshl => new OpCodeDescription(OpCode.Lshl);

        /// <summary>
        /// The 'ishr' opcode.
        /// </summary>
        //public static OpCodeDescription Ishr => new OpCodeDescription(OpCode.Ishr);

        /// <summary>
        /// The 'lshr' opcode.
        /// </summary>
        //public static OpCodeDescription Lshr => new OpCodeDescription(OpCode.Lshr);

        /// <summary>
        /// The 'iushr' opcode.
        /// </summary>
        //public static OpCodeDescription Iushr => new OpCodeDescription(OpCode.Iushr);

        /// <summary>
        /// The 'lushr' opcode.
        /// </summary>
        //public static OpCodeDescription Lushr => new OpCodeDescription(OpCode.Lushr);

        /// <summary>
        /// The 'iand' opcode.
        /// </summary>
        //public static OpCodeDescription Iand => new OpCodeDescription(OpCode.Iand);

        /// <summary>
        /// The 'land' opcode.
        /// </summary>
        //public static OpCodeDescription Land => new OpCodeDescription(OpCode.Land);

        /// <summary>
        /// The 'ior' opcode.
        /// </summary>
        //public static OpCodeDescription Ior => new OpCodeDescription(OpCode.Ior);

        /// <summary>
        /// The 'lor' opcode.
        /// </summary>
        //public static OpCodeDescription Lor => new OpCodeDescription(OpCode.Lor);

        /// <summary>
        /// The 'ixor' opcode.
        /// </summary>
        //public static OpCodeDescription Ixor => new OpCodeDescription(OpCode.Ixor);

        /// <summary>
        /// The 'lxor' opcode.
        /// </summary>
        //public static OpCodeDescription Lxor => new OpCodeDescription(OpCode.Lxor);

        /// <summary>
        /// The 'iinc' opcode.
        /// </summary>
        //public static OpCodeDescription Iinc => new OpCodeDescription(OpCode.Iinc);

        /// <summary>
        /// The 'i2l' opcode.
        /// </summary>
        //public static OpCodeDescription I2l => new OpCodeDescription(OpCode.I2l);

        /// <summary>
        /// The 'i2f' opcode.
        /// </summary>
        //public static OpCodeDescription I2f => new OpCodeDescription(OpCode.I2f);

        /// <summary>
        /// The 'i2d' opcode.
        /// </summary>
        //public static OpCodeDescription I2d => new OpCodeDescription(OpCode.I2d);

        /// <summary>
        /// The 'l2i' opcode.
        /// </summary>
        //public static OpCodeDescription L2i => new OpCodeDescription(OpCode.L2i);

        /// <summary>
        /// The 'l2f' opcode.
        /// </summary>
        //public static OpCodeDescription L2f => new OpCodeDescription(OpCode.L2f);

        /// <summary>
        /// The 'l2d' opcode.
        /// </summary>
        //public static OpCodeDescription L2d => new OpCodeDescription(OpCode.L2d);

        /// <summary>
        /// The 'f2i' opcode.
        /// </summary>
        //public static OpCodeDescription F2i => new OpCodeDescription(OpCode.F2i);

        /// <summary>
        /// The 'f2l' opcode.
        /// </summary>
        //public static OpCodeDescription F2l => new OpCodeDescription(OpCode.F2l);

        /// <summary>
        /// The 'f2d' opcode.
        /// </summary>
        //public static OpCodeDescription F2d => new OpCodeDescription(OpCode.F2d);

        /// <summary>
        /// The 'd2i' opcode.
        /// </summary>
        //public static OpCodeDescription D2i => new OpCodeDescription(OpCode.D2i);

        /// <summary>
        /// The 'd2l' opcode.
        /// </summary>
        //public static OpCodeDescription D2l => new OpCodeDescription(OpCode.D2l);

        /// <summary>
        /// The 'd2f' opcode.
        /// </summary>
        //public static OpCodeDescription D2f => new OpCodeDescription(OpCode.D2f);

        /// <summary>
        /// The 'i2b' opcode.
        /// </summary>
        //public static OpCodeDescription I2b => new OpCodeDescription(OpCode.I2b);

        /// <summary>
        /// The 'i2c' opcode.
        /// </summary>
        //public static OpCodeDescription I2c => new OpCodeDescription(OpCode.I2c);

        /// <summary>
        /// The 'i2s' opcode.
        /// </summary>
        //public static OpCodeDescription I2s => new OpCodeDescription(OpCode.I2s);

        /// <summary>
        /// The 'lcmp' opcode.
        /// </summary>
        //public static OpCodeDescription Lcmp => new OpCodeDescription(OpCode.Lcmp);

        /// <summary>
        /// The 'fcmpl' opcode.
        /// </summary>
        //public static OpCodeDescription Fcmpl => new OpCodeDescription(OpCode.Fcmpl);

        /// <summary>
        /// The 'fcmpg' opcode.
        /// </summary>
        //public static OpCodeDescription Fcmpg => new OpCodeDescription(OpCode.Fcmpg);

        /// <summary>
        /// The 'dcmpl' opcode.
        /// </summary>
        //public static OpCodeDescription Dcmpl => new OpCodeDescription(OpCode.Dcmpl);

        /// <summary>
        /// The 'dcmpg' opcode.
        /// </summary>
        //public static OpCodeDescription Dcmpg => new OpCodeDescription(OpCode.Dcmpg);

        /// <summary>
        /// The 'ifeq' opcode.
        /// </summary>
        //public static OpCodeDescription Ifeq => new OpCodeDescription(OpCode.Ifeq);

        /// <summary>
        /// The 'ifne' opcode.
        /// </summary>
        //public static OpCodeDescription Ifne => new OpCodeDescription(OpCode.Ifne);

        /// <summary>
        /// The 'iflt' opcode.
        /// </summary>
        //public static OpCodeDescription Iflt => new OpCodeDescription(OpCode.Iflt);

        /// <summary>
        /// The 'ifge' opcode.
        /// </summary>
        //public static OpCodeDescription Ifge => new OpCodeDescription(OpCode.Ifge);

        /// <summary>
        /// The 'ifgt' opcode.
        /// </summary>
        //public static OpCodeDescription Ifgt => new OpCodeDescription(OpCode.Ifgt);

        /// <summary>
        /// The 'ifle' opcode.
        /// </summary>
        //public static OpCodeDescription Ifle => new OpCodeDescription(OpCode.Ifle);

        /// <summary>
        /// The 'if_icmpeq' opcode.
        /// </summary>
        //public static OpCodeDescription IfIcmpeq => new OpCodeDescription(OpCode.IfIcmpeq);

        /// <summary>
        /// The 'if_icmpne' opcode.
        /// </summary>
        //public static OpCodeDescription IfIcmpne => new OpCodeDescription(OpCode.IfIcmpne);

        /// <summary>
        /// The 'if_icmplt' opcode.
        /// </summary>
        //public static OpCodeDescription IfIcmplt => new OpCodeDescription(OpCode.IfIcmplt);

        /// <summary>
        /// The 'if_icmpge' opcode.
        /// </summary>
        //public static OpCodeDescription IfIcmpge => new OpCodeDescription(OpCode.IfIcmpge);

        /// <summary>
        /// The 'if_icmpgt' opcode.
        /// </summary>
        //public static OpCodeDescription IfIcmpgt => new OpCodeDescription(OpCode.IfIcmpgt);

        /// <summary>
        /// The 'if_icmple' opcode.
        /// </summary>
        //public static OpCodeDescription IfIcmple => new OpCodeDescription(OpCode.IfIcmple);

        /// <summary>
        /// The 'if_acmpeq' opcode.
        /// </summary>
        //public static OpCodeDescription IfAcmpeq => new OpCodeDescription(OpCode.IfAcmpeq);

        /// <summary>
        /// The 'if_acmpne' opcode.
        /// </summary>
        //public static OpCodeDescription IfAcmpne => new OpCodeDescription(OpCode.IfAcmpne);

        /// <summary>
        /// The 'goto' opcode.
        /// </summary>
        //public static OpCodeDescription Goto => new OpCodeDescription(OpCode.Goto);

        /// <summary>
        /// The 'jsr' opcode.
        /// </summary>
        //public static OpCodeDescription Jsr => new OpCodeDescription(OpCode.Jsr);

        /// <summary>
        /// The 'ret' opcode.
        /// </summary>
        //public static OpCodeDescription Ret => new OpCodeDescription(OpCode.Ret);

        /// <summary>
        /// The 'tableswitch' opcode.
        /// </summary>
        //public static OpCodeDescription TableSwitch => new OpCodeDescription(OpCode.TableSwitch);

        /// <summary>
        /// The 'lookupswitch' opcode.
        /// </summary>
        //public static OpCodeDescription LookupSwitch => new OpCodeDescription(OpCode.LookupSwitch);

        /// <summary>
        /// The 'ireturn' opcode.
        /// </summary>
        //public static OpCodeDescription Ireturn => new OpCodeDescription(OpCode.Ireturn);

        /// <summary>
        /// The 'lreturn' opcode.
        /// </summary>
        //public static OpCodeDescription Lreturn => new OpCodeDescription(OpCode.Lreturn);

        /// <summary>
        /// The 'freturn' opcode.
        /// </summary>
        //public static OpCodeDescription Freturn => new OpCodeDescription(OpCode.Freturn);

        /// <summary>
        /// The 'dreturn' opcode.
        /// </summary>
        //public static OpCodeDescription Dreturn => new OpCodeDescription(OpCode.Dreturn);

        /// <summary>
        /// The 'areturn' opcode.
        /// </summary>
        //public static OpCodeDescription Areturn => new OpCodeDescription(OpCode.Areturn);

        /// <summary>
        /// The 'return' opcode.
        /// </summary>
        //public static OpCodeDescription Return => new OpCodeDescription(OpCode.Return);

        /// <summary>
        /// The 'getstatic' opcode.
        /// </summary>
        //public static OpCodeDescription GetStatic => new OpCodeDescription(OpCode.GetStatic);

        /// <summary>
        /// The 'putstatic' opcode.
        /// </summary>
        //public static OpCodeDescription PutStatic => new OpCodeDescription(OpCode.PutStatic);

        /// <summary>
        /// The 'getfield' opcode.
        /// </summary>
        //public static OpCodeDescription GetField => new OpCodeDescription(OpCode.GetField);

        /// <summary>
        /// The 'putfield' opcode.
        /// </summary>
        //public static OpCodeDescription PutField => new OpCodeDescription(OpCode.PutField);

        /// <summary>
        /// The 'invokevirtual' opcode.
        /// </summary>
        //public static OpCodeDescription InvokeVirtual => new OpCodeDescription(OpCode.InvokeVirtual);

        /// <summary>
        /// The 'invokespecial' opcode.
        /// </summary>
        //public static OpCodeDescription InvokeSpecial => new OpCodeDescription(OpCode.InvokeSpecial);

        /// <summary>
        /// The 'invokestatic' opcode.
        /// </summary>
        //public static OpCodeDescription InvokeStatic => new OpCodeDescription(OpCode.InvokeStatic);

        /// <summary>
        /// The 'invokeinterface' opcode.
        /// </summary>
        //public static OpCodeDescription InvokeInterface => new OpCodeDescription(OpCode.InvokeInterface);

        /// <summary>
        /// The 'invokedynamic' opcode.
        /// </summary>
        //public static OpCodeDescription InvokeDynamic => new OpCodeDescription(OpCode.InvokeDynamic);

        /// <summary>
        /// The 'new' opcode.
        /// </summary>
        //public static OpCodeDescription New => new OpCodeDescription(OpCode.New);

        /// <summary>
        /// The 'newarray' opcode.
        /// </summary>
        //public static OpCodeDescription Newarray => new OpCodeDescription(OpCode.Newarray);

        /// <summary>
        /// The 'anewarray' opcode.
        /// </summary>
        //public static OpCodeDescription Anewarray => new OpCodeDescription(OpCode.Anewarray);

        /// <summary>
        /// The 'arraylength' opcode.
        /// </summary>
        //public static OpCodeDescription Arraylength => new OpCodeDescription(OpCode.Arraylength);

        /// <summary>
        /// The 'athrow' opcode.
        /// </summary>
        //public static OpCodeDescription Athrow => new OpCodeDescription(OpCode.Athrow);

        /// <summary>
        /// The 'checkcast' opcode.
        /// </summary>
        //public static OpCodeDescription Checkcast => new OpCodeDescription(OpCode.Checkcast);

        /// <summary>
        /// The 'instanceof' opcode.
        /// </summary>
        //public static OpCodeDescription InstanceOf => new OpCodeDescription(OpCode.InstanceOf);

        /// <summary>
        /// The 'monitorenter' opcode.
        /// </summary>
        //public static OpCodeDescription MonitorEnter => new OpCodeDescription(OpCode.MonitorEnter);

        /// <summary>
        /// The 'monitorexit' opcode.
        /// </summary>
        //public static OpCodeDescription MonitorExit => new OpCodeDescription(OpCode.MonitorExit);

        /// <summary>
        /// The 'wide' opcode.
        /// </summary>
        //public static OpCodeDescription Wide => new OpCodeDescription(OpCode.Wide);

        /// <summary>
        /// The 'multianewarray' opcode.
        /// </summary>
        //public static OpCodeDescription Multianewarray => new OpCodeDescription(OpCode.Multianewarray);

        /// <summary>
        /// The 'ifnull' opcode.
        /// </summary>
        //public static OpCodeDescription IfNull => new OpCodeDescription(OpCode.IfNull);

        /// <summary>
        /// The 'ifnonnull' opcode.
        /// </summary>
        //public static OpCodeDescription IfNonNull => new OpCodeDescription(OpCode.IfNonNull);

        /// <summary>
        /// The 'goto_w' opcode.
        /// </summary>
        //public static OpCodeDescription GotoW => new OpCodeDescription(OpCode.GotoW);

        /// <summary>
        /// The 'jsr_w' opcode.
        /// </summary>
        //public static OpCodeDescription JsrW => new OpCodeDescription(OpCode.JsrW);

    }

}

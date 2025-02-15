﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectsEngine
{
    internal abstract class Builder
    {
        protected EffectBlock effectBlock;

        public EffectBlock Build() => effectBlock;
    }
}

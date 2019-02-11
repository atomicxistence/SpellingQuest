using System;

[Serializable]
public class FloatReference
{
    public bool UseConstant = true;
    public float Constant;
    public FloatVariable Variable;

    public float Value
    {
        get { return UseConstant ? Constant : Variable.Value; }
    }
}

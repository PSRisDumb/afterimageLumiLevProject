using UnityEngine;
public enum EaseType
{
    Linear,

    InSine, OutSine, InOutSine,
    InQuad, OutQuad, InOutQuad,
    InCubic, OutCubic, InOutCubic,
    InQuart, OutQuart, InOutQuart,
    InQuint, OutQuint, InOutQuint,

    InExpo, OutExpo, InOutExpo,
    InCirc, OutCirc, InOutCirc,

    InBack, OutBack, InOutBack,

    InElastic, OutElastic, InOutElastic,

    InBounce, OutBounce, InOutBounce
}
public static class Easing
{
    public static float Ease(EaseType type, float x)
    {
        x = Mathf.Clamp01(x);

        switch (type)
        {
            case EaseType.Linear: return x;

            case EaseType.InSine: return 1 - Mathf.Cos((x * Mathf.PI) / 2);
            case EaseType.OutSine: return Mathf.Sin((x * Mathf.PI) / 2);
            case EaseType.InOutSine: return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;

            case EaseType.InQuad: return x * x;
            case EaseType.OutQuad: return 1 - (1 - x) * (1 - x);
            case EaseType.InOutQuad:
                return x < 0.5f ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;

            case EaseType.InCubic: return x * x * x;
            case EaseType.OutCubic: return 1 - Mathf.Pow(1 - x, 3);
            case EaseType.InOutCubic:
                return x < 0.5f
                    ? 4 * x * x * x
                    : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;

            case EaseType.InQuart: return x * x * x * x;
            case EaseType.OutQuart: return 1 - Mathf.Pow(1 - x, 4);
            case EaseType.InOutQuart:
                return x < 0.5f
                    ? 8 * x * x * x * x
                    : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;

            case EaseType.InQuint: return x * x * x * x * x;
            case EaseType.OutQuint: return 1 - Mathf.Pow(1 - x, 5);
            case EaseType.InOutQuint:
                return x < 0.5f
                    ? 16 * x * x * x * x * x
                    : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;

            case EaseType.InExpo:
                return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);

            case EaseType.OutExpo:
                return x == 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);

            case EaseType.InOutExpo:
                if (x == 0) return 0;
                if (x == 1) return 1;
                return x < 0.5f
                    ? Mathf.Pow(2, 20 * x - 10) / 2
                    : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;

            case EaseType.InCirc:
                return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));

            case EaseType.OutCirc:
                return Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));

            case EaseType.InOutCirc:
                return x < 0.5f
                    ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
                    : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;

            case EaseType.InBack:
                {
                    const float c1 = 1.70158f;
                    const float c3 = c1 + 1;
                    return c3 * x * x * x - c1 * x * x;
                }

            case EaseType.OutBack:
                {
                    const float c1 = 1.70158f;
                    const float c3 = c1 + 1;
                    return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
                }

            case EaseType.InOutBack:
                {
                    const float c1 = 1.70158f;
                    const float c2 = c1 * 1.525f;

                    return x < 0.5f
                        ? Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2) / 2
                        : (Mathf.Pow(2 * x - 2, 2) *
                           ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
                }

            case EaseType.InBounce:
                return 1 - OutBounce(1 - x);

            case EaseType.OutBounce:
                return OutBounce(x);

            case EaseType.InOutBounce:
                return x < 0.5f
                    ? (1 - OutBounce(1 - 2 * x)) / 2
                    : (1 + OutBounce(2 * x - 1)) / 2;

            case EaseType.InElastic:
                return InElastic(x);

            case EaseType.OutElastic:
                return OutElastic(x);

            case EaseType.InOutElastic:
                return InOutElastic(x);
        }

        return x;
    }

    static float OutBounce(float x)
    {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (x < 1 / d1)
            return n1 * x * x;
        else if (x < 2 / d1)
        {
            x -= 1.5f / d1;
            return n1 * x * x + 0.75f;
        }
        else if (x < 2.5f / d1)
        {
            x -= 2.25f / d1;
            return n1 * x * x + 0.9375f;
        }
        else
        {
            x -= 2.625f / d1;
            return n1 * x * x + 0.984375f;
        }
    }

    static float InElastic(float x)
    {
        const float c4 = (2 * Mathf.PI) / 3;

        if (x == 0) return 0;
        if (x == 1) return 1;

        return -Mathf.Pow(2, 10 * x - 10) *
               Mathf.Sin((x * 10 - 10.75f) * c4);
    }

    static float OutElastic(float x)
    {
        const float c4 = (2 * Mathf.PI) / 3;

        if (x == 0) return 0;
        if (x == 1) return 1;

        return Mathf.Pow(2, -10 * x) *
               Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
    }

    static float InOutElastic(float x)
    {
        const float c5 = (2 * Mathf.PI) / 4.5f;

        if (x == 0) return 0;
        if (x == 1) return 1;

        return x < 0.5f
            ? -(Mathf.Pow(2, 20 * x - 10) *
               Mathf.Sin((20 * x - 11.125f) * c5)) / 2
            : (Mathf.Pow(2, -20 * x + 10) *
               Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
    }
}
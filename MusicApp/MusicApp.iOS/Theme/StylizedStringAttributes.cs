using System;
using Foundation;
using UIKit;

namespace MusicApp.iOS.Theme
{
    public class StylizedStringAttributes : NSObject
    {
        private readonly StylizedStringCase _stringCase;

        public StylizedStringAttributes(
            UIFont font,
            UIColor color,
            float letterSpace,
            nfloat lineHeightMultiplier,
            StylizedStringCase stringCase,
            UITextAlignment textAlignment = UITextAlignment.Left,
            NSUnderlineStyle underlineStyle = NSUnderlineStyle.None)
        {
            _stringCase = stringCase;

            NSMutableParagraphStyle paragraphStyle = null;

            if (lineHeightMultiplier != 1 || textAlignment != UITextAlignment.Left)
            {
                paragraphStyle = new NSMutableParagraphStyle
                {
                    LineHeightMultiple = lineHeightMultiplier,
                    Alignment = textAlignment
                };
            }

            StringAttributes = new UIStringAttributes
            {
                Font = font,
                ForegroundColor = color,
                KerningAdjustment = letterSpace,
                ParagraphStyle = paragraphStyle,
                UnderlineStyle = underlineStyle
            };
        }

        public UIStringAttributes StringAttributes { get; }

        public string AdjustCase(string text)
        {
            switch (_stringCase)
            {
                case StylizedStringCase.Upper:
                    return text?.ToUpper() ?? string.Empty;
                default:
                    return text ?? string.Empty;
            }
        }
    }
}
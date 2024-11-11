using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;
        private int systolic;
         private int diastolic;

        [Display(Name = "Systolic Pressure")]
        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { // mmHG
            get => systolic;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Systolic pressure cannot be negative.");
                systolic = value;
            }
        }                       

        [Display(Name = "Diastolic Pressure")]
        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { // mmHG
            get => diastolic;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Diastolic pressure cannot be negative.");
                diastolic = value;
            }
        }    

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                if (Systolic >= 140 || Diastolic >= 90) {
                    return BPCategory.High;
                }
                else if (Systolic >= 120 || Diastolic >= 80 ) {
                    return BPCategory.PreHigh;
                }
                else if (Systolic >= 90 || Diastolic >= 60 ) {
                    return BPCategory.Ideal;
                } else {
                    return BPCategory.Low;
                }
            }
        }
    }
}

using Prism.Mvvm;
using System;
using System.Text.Json.Serialization;

namespace AutoTune.Core.Models
{
	public partial class DelayApfFR
	{
		public class Params : BindableBase, ICloneable 
        {
			public class Row : BindableBase, ICloneable
			{

				private string _spkName = "";
                [JsonPropertyName("spk_name")]
                public string SpkName
				{
					get { return _spkName; }
					set { SetProperty(ref _spkName, value); }
				}

				private int _spkL = 0;
                [JsonPropertyName("spk_l")]
                public int SpkL
				{
					get { return _spkL; }
					set { SetProperty(ref _spkL, value); }
				}

				private int _spkR = 0;
                [JsonPropertyName("spk_r")]
                public int SpkR
				{
					get { return _spkR; }
					set { SetProperty(ref _spkR, value); }
				}

				private bool _applyApf = false;
                [JsonPropertyName("apply_apf")]
                public bool ApplyApf
                {
					get { return _applyApf; }
					set { SetProperty(ref _applyApf, value); }
				}

				private int _apfFcLeft = 10;
				[JsonPropertyName("apf_fc_l")]
				public int ApfFcLeft
                {
					get { return _apfFcLeft; }
					set {
                        value = Constants.CheckIntMinMax(value, Constants.delay_apf_fc_min, Constants.delay_apf_fc_max);
                        SetProperty(ref _apfFcLeft, value); }
				}

                private double _apfQLeft = 0.707;
                [JsonPropertyName("apf_q_l")]
                public double ApfQLeft
                {
                    get { return _apfQLeft; }
                    set
                    {
                        value = Constants.CheckDoubleMinMax(value, Constants.delay_apf_q_min, Constants.delay_apf_q_max, Constants.interval_3rd_decimal);
                        SetProperty(ref _apfQLeft, value);
                    }
                }

                private int _apfFcRight = 10;
				[JsonPropertyName("apf_fc_r")]
				public int ApfFcRight
                {
					get { return _apfFcRight; }
					set {
                        value = Constants.CheckIntMinMax(value, Constants.delay_apf_fc_min, Constants.delay_apf_fc_max);
                        SetProperty(ref _apfFcRight, value); }
				}

				private double _apfQRight = 0.707;
				[JsonPropertyName("apf_q_r")]
				public double ApfQRight
                {
					get { return _apfQRight; }
					set {
                        value = Constants.CheckDoubleMinMax(value, Constants.delay_apf_q_min, Constants.delay_apf_q_max, Constants.interval_3rd_decimal);
                        SetProperty(ref _apfQRight, value); }
				}

                private int _delay = 0;
                [JsonPropertyName("delay")]
                public int Delay
                {
                    get { return _delay; }
                    set { SetProperty(ref _delay, value); }
                }

                private bool _inv;
                [JsonPropertyName("inv")]
                public bool Inv
                {
                    get { return _inv; }
                    set { SetProperty(ref _inv, value); }
                }

                private int _fcMin = 120;
				[JsonPropertyName("fc_min")]
				public int FcMin
                {
					get { return _fcMin; }
					set {
                        value = Constants.CheckIntMinMax(value, Constants.delay_fc_min, FcMax);
                        SetProperty(ref _fcMin, value); }
				}

				private int _fcMax = 1000;
				[JsonPropertyName("fc_max")]
				public int FcMax
                {
					get { return _fcMax; }
					set {
                        value = Constants.CheckIntMinMax(value, FcMin, Constants.delay_fc_max);
                        SetProperty(ref _fcMax, value); }
				}

				public Row(Speaker speaker)
                {
					SpkName = speaker.Type;
                    SpkL = speaker.LeftID;
                    SpkR = speaker.RightID;
                    ApplyApf = false;
                    ApfFcLeft = 10;
                    ApfQLeft = 0.707;
                    ApfFcRight = 10;
                    ApfQRight = 0.707;
                    Delay = 0;
                    Inv = false;
                    FcMin = 120;
                    FcMax = 1000;
                }

                public Row() {}

                public object Clone()
                {
                    return new Row()
					{
						SpkName = this.SpkName,
						SpkL = this.SpkL,
						SpkR = this.SpkR,
						ApplyApf = this.ApplyApf,
						ApfFcLeft = this.ApfFcLeft,
						ApfFcRight = this.ApfFcRight,
						ApfQLeft = this.ApfQLeft,
						ApfQRight = this.ApfQRight,
						Delay = this.Delay,
                        Inv = this.Inv,
						FcMin = this.FcMin,
						FcMax = this.FcMax,
					};
                }
            };

			public class Mix_Out : BindableBase, ICloneable
			{
                private string _spkName = "";
                [JsonPropertyName("spk_name")]
                public string SpkName
                {
                    get { return _spkName; }
                    set { SetProperty(ref _spkName, value); }
                }

                private bool _output = false;
                [JsonPropertyName("output")]
                public bool Output
                {
                    get { return _output; }
                    set { SetProperty(ref _output, value); }
                }

                private int _spkL = 0;
                [JsonPropertyName("spk_l")]
                public int SpkL
                {
                    get { return _spkL; }
                    set { SetProperty(ref _spkL, value); }
                }

                private int _spkR = 0;
                [JsonPropertyName("spk_r")]
                public int SpkR
                {
                    get { return _spkR; }
                    set { SetProperty(ref _spkR, value); }
                }

                public Mix_Out(Speaker speaker)
                {
                    SpkName = speaker.Type;
                    Output = false;
                    SpkL = speaker.LeftID;
                    SpkR = speaker.RightID;
                }

                public Mix_Out() {}

                public object Clone()
                {
                    return new Mix_Out()
                    {
                        SpkName = this.SpkName,
                        Output = this.Output,
                        SpkL = this.SpkL,
                        SpkR = this.SpkR
                    };
                }
            }

            private string _name;
            [JsonPropertyName("name")]
            public string Name
            {
                get { return _name; }
                set { SetProperty(ref _name, value); }
            }

			private Row _frontSp;
            [JsonPropertyName("front_sp")]
            public Row FrontSp
            {
				get { return _frontSp; }
				set { SetProperty(ref _frontSp, value); }
			}

			private Row _rearSp;
            [JsonPropertyName("rear_sp")]
            public Row RearSp
            {
				get { return _rearSp; }
				set { SetProperty(ref _rearSp, value); }
			}

            private Mix_Out _mixOut;
            [JsonPropertyName("mix_out")]
            public Mix_Out MixOut
            {
                get { return _mixOut; }
                set { SetProperty(ref _mixOut, value); }
            }


            private string _calcMode;
            [JsonPropertyName("calc_mode")]
            public string CalcMode
            {
                get { return _calcMode; }
                set { SetProperty(ref _calcMode, value); }
            }

            private string _adjustPoint;
            [JsonPropertyName("adjust_point")]
            public string AdjustPoint
            {
                get { return _adjustPoint; }
                set { SetProperty(ref _adjustPoint, value); }
            }

            public Params (Adjustment adjustment)
			{
				Name = adjustment.AdjustmentName;
				FrontSp = new Row(adjustment.Row1Pair);
				RearSp = new Row(adjustment.Row2Pair);
				MixOut = new Mix_Out(adjustment.MixOutPair);
                CalcMode = Constants.CalcModeListShow[0];
                AdjustPoint = Constants.AdjustList[0];
            }

			public Params () { }

            public object Clone()
            {
				return new Params() {
					Name = this.Name,
					FrontSp = (Row)this.FrontSp.Clone(),
					RearSp = (Row)this.RearSp.Clone(),
					MixOut = (Mix_Out)this.MixOut.Clone(),
					CalcMode = this.CalcMode,
					AdjustPoint = this.AdjustPoint
				};
            }
        }
	}
}

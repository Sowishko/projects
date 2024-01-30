object Form1: TForm1
  Left = 521
  Top = 120
  Width = 906
  Height = 675
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnActivate = FormActivate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 608
    Top = 56
    Width = 277
    Height = 13
    Caption = #1050#1086#1083'-'#1074#1086' '#1089#1090#1088#1072#1085#1080#1094', '#1080#1084#1077#1102#1097#1080#1093' '#1072#1090#1088#1080#1073#1091#1090' PAGE_READWRITE '
  end
  object Label2: TLabel
    Left = 24
    Top = 16
    Width = 96
    Height = 13
    Caption = 'z=sqrt((x+3)/(x-3))'
  end
  object Button1: TButton
    Left = 608
    Top = 16
    Width = 75
    Height = 25
    Caption = #1047#1072#1076#1072#1085#1080#1077#8470'2'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Edit2: TEdit
    Left = 608
    Top = 72
    Width = 49
    Height = 21
    TabOrder = 1
  end
  object Memo2: TMemo
    Left = 384
    Top = 16
    Width = 217
    Height = 593
    Lines.Strings = (
      'Memo2')
    TabOrder = 2
  end
  object Button2: TButton
    Left = 296
    Top = 16
    Width = 75
    Height = 25
    Caption = #1047#1072#1076#1072#1085#1080#1077#8470'1'
    TabOrder = 3
    OnClick = Button2Click
  end
  object Memo3: TMemo
    Left = 16
    Top = 40
    Width = 273
    Height = 281
    Lines.Strings = (
      'Memo3')
    TabOrder = 4
  end
end

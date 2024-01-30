object Form1: TForm1
  Left = 809
  Top = 95
  Width = 758
  Height = 676
  Caption = #1048#1089#1087#1086#1083#1100#1079#1086#1074#1072#1085#1080#1077' '#1074#1080#1088#1090#1091#1072#1083#1100#1085#1086#1081' '#1087#1072#1084#1103#1090#1080' '#1074' '#1087#1088#1080#1083#1086#1078#1077#1085#1080#1080
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnActivate = OnActivate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 48
    Width = 62
    Height = 14
    Caption = #1042#1074#1077#1076#1080#1090#1077' n:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = 14
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 8
    Top = 16
    Width = 61
    Height = 14
    Caption = #1042#1074#1077#1076#1080#1090#1077' x:'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = 14
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 216
    Top = 8
    Width = 97
    Height = 28
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1087#1077#1088#1074#1099#1081' '#1072#1076#1088#1077#1089':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = 14
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    WordWrap = True
  end
  object Label4: TLabel
    Left = 216
    Top = 48
    Width = 95
    Height = 28
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1074#1090#1086#1088#1086#1081' '#1072#1076#1088#1077#1089':'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = 14
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    WordWrap = True
  end
  object Edit1: TEdit
    Left = 80
    Top = 48
    Width = 121
    Height = 24
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 0
    OnKeyPress = KeyPressPer
  end
  object Edit2: TEdit
    Left = 80
    Top = 16
    Width = 121
    Height = 24
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 1
    OnKeyPress = KeyPressPer
  end
  object Button1: TButton
    Left = 72
    Top = 96
    Width = 75
    Height = 25
    Caption = #1042#1099#1095#1080#1089#1083#1080#1090#1100
    TabOrder = 2
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 16
    Top = 152
    Width = 185
    Height = 457
    Lines.Strings = (
      'Memo1')
    ReadOnly = True
    TabOrder = 3
  end
  object Edit3: TEdit
    Left = 328
    Top = 8
    Width = 177
    Height = 24
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    MaxLength = 10
    ParentFont = False
    TabOrder = 4
    OnKeyPress = OnKeyPressEdit
  end
  object Edit4: TEdit
    Left = 328
    Top = 48
    Width = 177
    Height = 24
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'Tahoma'
    Font.Style = []
    MaxLength = 10
    ParentFont = False
    TabOrder = 5
    OnKeyPress = OnKeyPressEdit
  end
  object Memo2: TMemo
    Left = 264
    Top = 152
    Width = 241
    Height = 457
    Lines.Strings = (
      'Memo1')
    ReadOnly = True
    TabOrder = 6
  end
  object Button2: TButton
    Left = 296
    Top = 88
    Width = 113
    Height = 41
    Caption = #1048#1085#1092#1086#1088#1084#1072#1094#1080#1103' '#1086' '#1089#1086#1089#1090#1086#1103#1085#1080#1080' '#1089#1090#1088#1072#1085#1080#1094
    TabOrder = 7
    WordWrap = True
    OnClick = Button2Click
  end
  object Memo3: TMemo
    Left = 544
    Top = 152
    Width = 185
    Height = 457
    Lines.Strings = (
      'Memo3')
    TabOrder = 8
  end
  object Button3: TButton
    Left = 568
    Top = 88
    Width = 137
    Height = 41
    Caption = #1047#1072#1088#1077#1079#1077#1088#1074#1080#1088#1086#1074#1072#1085#1085#1099#1077
    TabOrder = 9
    OnClick = Button3Click
  end
end

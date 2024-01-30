object Form1: TForm1
  Left = 192
  Top = 124
  Width = 475
  Height = 563
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnActivate = FormActivate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 136
    Top = 224
    Width = 182
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1072#1076#1088#1077#1089' '#1074#1080#1088#1090#1091#1072#1083#1100#1085#1086#1081' '#1087#1072#1084#1103#1090#1080
  end
  object Label2: TLabel
    Left = 136
    Top = 264
    Width = 127
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1072#1090#1088#1080#1073#1091#1090' '#1079#1072#1097#1080#1090#1099
  end
  object Label3: TLabel
    Left = 136
    Top = 304
    Width = 207
    Height = 13
    Caption = #1050#1086#1083#1080#1095#1077#1089#1090#1074#1086' '#1076#1086#1073#1072#1074#1083#1103#1077#1084#1099#1093' '#1073#1072#1081#1090' ('#1089#1090#1088#1072#1085#1080#1094')'
  end
  object Label4: TLabel
    Left = 136
    Top = 344
    Width = 103
    Height = 13
    Caption = #1057#1074#1086#1073#1086#1076#1085#1099#1077' '#1088#1077#1075#1080#1086#1085#1099
  end
  object Button1: TButton
    Left = 16
    Top = 40
    Width = 113
    Height = 25
    Caption = 'SysInfo'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 16
    Top = 72
    Width = 113
    Height = 25
    Caption = 'GlobalMemoryStatus'
    TabOrder = 1
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 16
    Top = 104
    Width = 113
    Height = 25
    Caption = 'VitrualQuery'
    TabOrder = 2
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 16
    Top = 136
    Width = 113
    Height = 25
    Caption = 'VirtualAlloc'
    TabOrder = 3
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 16
    Top = 168
    Width = 113
    Height = 25
    Caption = 'VirtualFree'
    TabOrder = 4
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 16
    Top = 200
    Width = 113
    Height = 25
    Caption = 'VirtualProtect'
    TabOrder = 5
    OnClick = Button6Click
  end
  object Button7: TButton
    Left = 16
    Top = 232
    Width = 113
    Height = 25
    Caption = #1042#1099#1093#1086#1076
    TabOrder = 6
    OnClick = Button7Click
  end
  object Memo1: TMemo
    Left = 136
    Top = 40
    Width = 225
    Height = 177
    Lines.Strings = (
      'Memo1')
    TabOrder = 7
  end
  object Edit1: TEdit
    Left = 136
    Top = 240
    Width = 225
    Height = 21
    TabOrder = 8
  end
  object Edit2: TEdit
    Left = 136
    Top = 280
    Width = 225
    Height = 21
    TabOrder = 9
  end
  object Edit3: TEdit
    Left = 136
    Top = 320
    Width = 225
    Height = 21
    TabOrder = 10
  end
  object Memo2: TMemo
    Left = 136
    Top = 360
    Width = 225
    Height = 113
    Lines.Strings = (
      'Memo2')
    TabOrder = 11
  end
end

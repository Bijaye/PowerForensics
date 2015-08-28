﻿Import-Module -Force $PSScriptRoot\..\PowerForensics.psd1

Describe 'Get-MBR' {
    Context 'No parameters provided' {
        It 'fails' {
            { Get-MBR } | Should Throw
        }
    }    
    Context 'Path is provided' { 
        It 'should not error' {
            { Get-MBR -Path \\.\PHYSICALDRIVE0 } | Should Not Throw
        }
    }
}
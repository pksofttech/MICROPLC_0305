LDmicro0.1
MICRO=Microchip PIC16F876 28-PDIP or 28-SOIC
CYCLE=1000
CRYSTAL=20000000
BAUD=2400
COMPILED=C:\Documents and Settings\Jean Marie\Mijn documenten\copy_ebooks\µpc\LDmicro\4094_shift.hex

IO LIST
    Yclock at 26
    Ydata at 25
    Ystrobe at 3
END

PROGRAM
RUNG
    COMMENT -------example for the 4094 by MGP  21/12/2010--- revised 30/01/2012\r\n********************************************************************
END
RUNG
    CONTACTS Rpuls 1
    COIL Rpuls 0 0 0
END
RUNG
    CONTACTS Rpuls 0
    CTC Ccounter 8
END
RUNG
    COMMENT -- BYTE is the variable to display
END
RUNG
    MOVE byte 240
END
RUNG
    EQU Ccounter 0
    MOVE data byte
END
RUNG
    EQU Ccounter 1
    GEQ data 128
    PARALLEL
        COIL Rbit8 0 0 0
        SUB data data 128
    END
END
RUNG
    EQU Ccounter 2
    GEQ data 64
    PARALLEL
        COIL Rbit7 0 0 0
        SUB data data 64
    END
END
RUNG
    EQU Ccounter 3
    GEQ data 32
    PARALLEL
        COIL Rbit6 0 0 0
        SUB data data 32
    END
END
RUNG
    EQU Ccounter 4
    GEQ data 16
    PARALLEL
        COIL Rbit5 0 0 0
        SUB data data 16
    END
END
RUNG
    EQU Ccounter 5
    GEQ data 8
    PARALLEL
        COIL Rbit4 0 0 0
        SUB data data 8
    END
END
RUNG
    EQU Ccounter 6
    GEQ data 4
    PARALLEL
        COIL Rbit3 0 0 0
        SUB data data 4
    END
END
RUNG
    EQU Ccounter 7
    GEQ data 2
    PARALLEL
        COIL Rbit2 0 0 0
        SUB data data 2
    END
END
RUNG
    EQU Ccounter 8
    GEQ data 1
    COIL Rbit1 0 0 0
END
RUNG
    COMMENT --outputs to input pins of the 4094: data, strobe, clock 
END
RUNG
    PARALLEL
        CONTACTS Rbit8 0
        CONTACTS Rbit7 0
        CONTACTS Rbit6 0
        CONTACTS Rbit5 0
        CONTACTS Rbit4 0
        CONTACTS Rbit3 0
        CONTACTS Rbit2 0
        CONTACTS Rbit1 0
    END
    COIL Ydata 0 0 0
END
RUNG
    EQU Ccounter 0
    COIL Ystrobe 0 0 0
END
RUNG
    NEQ Ccounter 0
    CONTACTS Rpuls 0
    COIL Yclock 0 0 0
END

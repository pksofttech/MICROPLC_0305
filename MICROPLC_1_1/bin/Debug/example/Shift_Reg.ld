# LD FORMAT copy Form LDMICRO#
HARDWARE
ArUnitControl 32IO
IO LIST
X1 at X00
Ys00 at Y00
Ys01 at Y02
Ys02 at Y04
Ys03 at Y06
Ys04 at Y08
Ys05 at Y10
Ys06 at Y12
Ys07 at Y14
Ytest at Y15
Ytest2 at Y01
END
PROGRAM
RUNG
	OSR
	SHIFT_REG Stest 1
END
RUNG
	END
RUNG
	CONTACTS X1 1 1 0
	TPC T100 40 40
	PARALLEL
		SHIFT_LEFT Stest
		COIL Ytest 0 0 0 0
		COIL Ytest2 1 0 0 0
	END
END
RUNG
	CONTACTS Stest 0 0 0 8456 0
	COIL Ys00 0 0 0 0
END
RUNG
	CONTACTS Stest 0 0 0 8456 1
	COIL Ys01 0 0 0 0
END
RUNG
	CONTACTS Stest 0 0 0 8456 2
	COIL Ys02 0 0 0 0
END
RUNG
	CONTACTS Stest 0 0 0 8456 3
	COIL Ys03 0 0 0 0
END
RUNG
	CONTACTS Stest 0 0 0 8456 4
	COIL Ys04 0 0 0 0
END
RUNG
	CONTACTS Stest 0 0 0 8456 5
	COIL Ys05 0 0 0 0
END
RUNG
	CONTACTS Stest 0 0 0 8456 6
	COIL Ys06 0 0 0 0
END
RUNG
	CONTACTS Stest 0 0 0 8456 7
	PARALLEL
		COIL Ys07 0 0 0 0
		SHIFT_INBIT Stest
	END
END

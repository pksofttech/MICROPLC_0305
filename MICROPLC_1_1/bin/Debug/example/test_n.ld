# LD FORMAT copy Form LDMICRO#
HARDWARE
Arduino/Genuino UNO
IO LIST
X2 at A0
X3 at A1
X4 at A2
Xreset_count at A4
XStep at A3
Y05 at D0
YLED_1 at D1
YLED_10 at D2
YLED_11 at D3
YLED_12 at D4
YLED_13 at D5
YLED_14 at D6
YLED_15 at D7
YLED_16 at D8
YLED_2 at D9
YLED_3 at D10
YLED_4 at Y03
YLED_6 at Y05
YLED_7 at Y06
YLED_8 at Y07
YLED_9 at Y08
END
PROGRAM
RUNG
	PARALLEL
		CONTACTS XStep 1 0 0
		SERIES
			CONTACTS X2 0 0 0
			TPC T1 50 50
		END
		SERIES
			CONTACTS X3 0 0 0
			TPC T2 75 75
		END
		SERIES
			CONTACTS X4 0 0 0
			TPC T3 100 100
		END
	END
	COIL CNum 0 0 0 1 16 1
END
RUNG
	CONTACTS Xreset_count 0 0 0
	COIL CNum 0 1 0 1 16 1
END
RUNG
	PARALLEL
		EQU CNum 1
		EQU CNum 16
	END
	COIL YLED_1 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 2
		EQU CNum 15
	END
	COIL YLED_2 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 3
		EQU CNum 14
	END
	COIL YLED_3 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 4
		EQU CNum 13
	END
	COIL YLED_4 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 5
		EQU CNum 12
	END
	COIL Y05 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 6
		EQU CNum 11
	END
	COIL YLED_6 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 7
		EQU CNum 10
	END
	COIL YLED_7 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 8
		EQU CNum 9
	END
	COIL YLED_8 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 9
		EQU CNum 8
	END
	COIL YLED_9 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 10
		EQU CNum 7
	END
	COIL YLED_10 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 11
		EQU CNum 6
	END
	COIL YLED_11 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 12
		EQU CNum 5
	END
	COIL YLED_12 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 13
		EQU CNum 4
	END
	COIL YLED_13 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 14
		EQU CNum 3
	END
	COIL YLED_14 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 15
		EQU CNum 2
	END
	COIL YLED_15 0 0 0 0
END
RUNG
	PARALLEL
		EQU CNum 16
		EQU CNum 1
	END
	COIL YLED_16 0 0 0 0
END
